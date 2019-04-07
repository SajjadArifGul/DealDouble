using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.Code.Enums;
using DealDouble.Web.Models;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        DashboardService service = new DashboardService();
        AuctionsService auctionsService = new AuctionsService();

        private DealDoubleUserManager _userManager;

        private DealDoubleRoleManager _roleManager;

        public DashboardController()
        {
        }

        public DashboardController(DealDoubleUserManager userManager, DealDoubleRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        
        public DealDoubleUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<DealDoubleUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public DealDoubleRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<DealDoubleRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            model.Page = Pages.Dashboard;

            model.AuctionsCount = service.GetAuctionCount();
            model.BidsCount = service.GetBidsCount();
            model.CommentsCount = service.GetCommentsCount();
            model.UserCount = service.GetUserCount();
            model.RolesCount = service.GetRolesCount();
            model.CategoriesCount = service.GetCategoriesCount();

            return View(model);
        }

        public ActionResult Users(string roleID, string searchTerm, int? pageNo)
        {
            UsersViewModel model = new UsersViewModel();
            model.PageTitle = "Users";
            model.PageDescription = "Users Listing Page";

            model.RoleID = roleID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo;

            model.Roles = RoleManager.Roles.ToList();

            return View(model);
        }
        
        public ActionResult UsersListing(string roleID, string searchTerm, int? pageNo)
        {
            var pageSize = 10;

            UsersListingViewModel model = new UsersListingViewModel();
            
            model.RoleID = roleID;
            model.SearchTerm = searchTerm;
            
            var users = UserManager.Users;

            if (!string.IsNullOrEmpty(roleID))
            {
                users = users.Where(x => x.Roles.FirstOrDefault(y => y.RoleId == roleID) != null);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(x => x.Email.ToLower().Contains(searchTerm.ToLower()) || x.UserName.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;

            var skipCount = (pageNo.Value - 1) * pageSize;

            model.Users = users.OrderBy(x=>x.Email).Skip(skipCount).Take(pageSize).ToList();
            
            model.Pager = new Pager(users.Count(), pageNo, pageSize);

            return PartialView(model);
        }

        public async Task<ActionResult> UsersDetails(string userID, bool isPartial = false)
        {
            UserDetailsViewModel model = new UserDetailsViewModel();

            var user = await UserManager.FindByIdAsync(userID);

            if(user != null)
            {
                model.User = user;
            }

            if(isPartial || Request.IsAjaxRequest())
            {
                return PartialView("_UsersDetails", model); //_UsersDetails.cshtml
            }
            else
            {
                return View(model); //"UserDetails.cshtml"
            }
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUserDetails(UserDetailsViewModel model)
        {
            JsonResult jResult = new JsonResult();
            
            if (model != null)
            {
                var user = await UserManager.FindByIdAsync(model.ID);

                if (user != null)
                {
                    user.FullName = model.FullName;
                    user.Country = model.Country;
                    user.City = model.City;
                    user.Address = model.Address;

                    var result = await UserManager.UpdateAsync(user);

                    jResult.Data = new { Success = result.Succeeded };

                    return jResult;
                }
            }

            jResult.Data = new { Success = false };
            return jResult;        
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUserDetails(string userID)
        {
            JsonResult jResult = new JsonResult();

            if (!string.IsNullOrEmpty(userID))
            {
                var user = await UserManager.FindByIdAsync(userID);

                if (user != null)
                {
                    var result = await UserManager.DeleteAsync(user);

                    jResult.Data = new { Success = result.Succeeded };

                    return jResult;
                }
            }

            jResult.Data = new { Success = false };
            return jResult;
        }
        
        public async Task<ActionResult> UsersRoles(string userID)
        {
            UserRolesViewModel model = new UserRolesViewModel();

            model.AvailableRoles = RoleManager.Roles.ToList();

            if(!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);

                if(model.User != null)
                {
                    model.UserRoles = model.User.Roles.Select(userRole => model.AvailableRoles.FirstOrDefault(role => role.Id == userRole.RoleId)).ToList();
                }
            }

            return PartialView("_UsersRoles", model);
        }
        
        public async Task<ActionResult> AssignUserRole(string userID, string roleID)
        {
            if(!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
               var user = await UserManager.FindByIdAsync(userID);

                if(user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);

                    if(role != null)
                    {
                        await UserManager.AddToRoleAsync(userID, role.Name);
                    }
                }
            }

            return RedirectToAction("UsersRoles", new { userID= userID });
        }
        
        public async Task<ActionResult> DeleteUserRole(string userID, string roleID)
        {
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                var user = await UserManager.FindByIdAsync(userID);

                if (user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);

                    if (role != null)
                    {
                        await UserManager.RemoveFromRoleAsync(userID, role.Name);
                    }
                }
            }

            return RedirectToAction("UsersRoles", new { userID = userID });
        }

        public ActionResult Roles(string searchTerm, int? pageNo)
        {
            RolesViewModel model = new RolesViewModel();
            model.PageTitle = "Roles";
            model.PageDescription = "Roles Listing Page";

            model.SearchTerm = searchTerm;
            model.PageNo = pageNo;
            
            return View(model);
        }

        public ActionResult RolesListing(string searchTerm, int? pageNo)
        {
            var pageSize = 10;

            RolesListingViewModel model = new RolesListingViewModel();

            model.SearchTerm = searchTerm;

            var roles = RoleManager.Roles;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;

            var skipCount = (pageNo.Value - 1) * pageSize;

            model.Roles = roles.OrderBy(x => x.Name).Skip(skipCount).Take(pageSize).ToList();

            model.Pager = new Pager(RoleManager.Roles.Count(), pageNo, pageSize);

            return PartialView(model);
        }

        public async Task<ActionResult> RoleDetails(string roleID)
        {
            RoleDetailsViewModel model = new RoleDetailsViewModel();

            var role = await RoleManager.FindByIdAsync(roleID);
            
            if (role != null)
            {
                model.Role = role;
            }

            if(Request.IsAjaxRequest())
            {
                return PartialView("_RoleDetails", model);
            }
            else
            {
                return View(model);
            }
        }

        public async Task<ActionResult> RoleUsers(string roleID, int? pageNo)
        {
            var pageSize = 10;

            RoleUsersViewModel model = new RoleUsersViewModel();

            var role = await RoleManager.FindByIdAsync(roleID);

            if (role != null)
            {
                model.RoleID = role.Id;
                pageNo = pageNo ?? 1;

                var skipCount = (pageNo.Value - 1) * pageSize;
                var users = role.Users.OrderBy(x => x.UserId).Skip(skipCount).Take(pageSize);

                model.RoleUsers = new List<Entities.DealDoubleUser>();
                foreach (var user in users)
                {
                    model.RoleUsers.Add(await UserManager.FindByIdAsync(user.UserId));
                }

                model.Pager = new Pager(role.Users.Count(), pageNo, pageSize);
            }

            return PartialView(model);
        }

        [HttpPost]
        public async Task<JsonResult> CreateRole(string roleName)
        {
            JsonResult result = new JsonResult();

            if (!string.IsNullOrEmpty(roleName))
            {
                var res = await RoleManager.CreateAsync(new IdentityRole() { Name = roleName });

                result.Data = new { Success = res.Succeeded, Message = string.Join(", ", res.Errors) };
                return result;
            }

            result.Data = new { Success = false, Message = "An error has occured while creating Role." };
            return result;
        }

        [HttpPost]
        public async Task<JsonResult> UpdateRoleDetails(string roleID, string roleName)
        {
            JsonResult result = new JsonResult();

            if (!string.IsNullOrEmpty(roleID) && !string.IsNullOrEmpty(roleName))
            {
                var role = await RoleManager.FindByIdAsync(roleID);

                if (role != null && !role.Name.ToLower().Equals("administrator"))
                {
                    role.Name = roleName;

                    var res = await RoleManager.UpdateAsync(role);

                    result.Data = new { Success = res.Succeeded, Message = string.Join(", ", res.Errors) };
                    return result;
                }
            }

            result.Data = new { Success = false, Message = "An error has occured while updating Role Details." };
            return result;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteRoleDetails(string roleID)
        {
            JsonResult result = new JsonResult();

            if (!string.IsNullOrEmpty(roleID))
            {
                var role = await RoleManager.FindByIdAsync(roleID);

                if (role != null && !role.Name.ToLower().Equals("administrator"))
                {
                    var res = await RoleManager.DeleteAsync(role);

                    result.Data = new { Success = res.Succeeded, Message = string.Join(", ", res.Errors) };
                    return result;
                }
            }

            result.Data = new { Success = false, Message = "An error has occured while deleting Role Details." };
            return result;
        }

        public async Task<ActionResult> UsersComments(string userID, string searchTerm, int? pageNo, int entityID = (int)EntityEnums.Auction)
        {
            var pageSize = 1;

            UserCommentsViewModel model = new UserCommentsViewModel();

            if (!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);

                if (model.User != null)
                {
                    pageNo = pageNo ?? 1;

                    model.UserComments = service.GetCommentsByUser(userID, searchTerm, entityID, pageNo, pageSize);

                    if (model.UserComments != null && model.UserComments.Count > 0)
                    {
                        var auctionIDs = model.UserComments.Select(x => x.RecordID).ToList();

                        model.CommentedAuctions = auctionsService.GetAuctionsByIDs(auctionIDs);
                    }

                    var totalCount = service.GetCommentsTotalCountByUser(userID, searchTerm, entityID);

                    model.Pager = new Pager(totalCount, pageNo, pageSize);
                }
            }

            return PartialView("_UsersComments", model);
        }

    }
}