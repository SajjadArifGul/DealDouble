using DealDouble.Services;
using DealDouble.Web.Code.Enums;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        DashboardService service = new DashboardService();
        
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

            model.UserCount = service.GetUserCount();
            model.AuctionsCount = service.GetAuctionCount();
            model.BidsCount = service.GetBidsCount();

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

            model.Pager = new Pager(roles.Count(), pageNo, pageSize);

            return PartialView(model);
        }

    }
}