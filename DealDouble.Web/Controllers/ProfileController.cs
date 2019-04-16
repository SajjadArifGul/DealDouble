using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        #region global variables and constructors
        DashboardService service = new DashboardService();
        AuctionsService auctionsService = new AuctionsService();

        private DealDoubleUserManager _userManager;
        private DealDoubleSignInManager _signInManager;

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

        public DealDoubleSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<DealDoubleSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ProfileController(DealDoubleUserManager userManager, DealDoubleSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ProfileController()
        {

        }
        #endregion
        
        public ActionResult Index()
        {
            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.PageTitle = "Profile";
            model.PageDescription = "Review your profile";

            model.User = UserManager.FindById(User.Identity.GetUserId());

            return View(model);
        }
        
        public ActionResult UsersDetails()
        {
            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.User = UserManager.FindById(User.Identity.GetUserId());

            return PartialView("_UsersDetails", model);
        }
        
        public async Task<JsonResult> UpdateUsersDetails(UpdateProfileDetailsViewModel model)
        {
            JsonResult result = new JsonResult();

            if(!ModelState.IsValid)
            {
                result.Data = new { Success = false, Message = "Invalid Data" };
            }
            else
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                if (user != null)
                {
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Country = model.Country;
                    user.City = model.City;
                    user.Address = model.Address;

                    var updateOp = await UserManager.UpdateAsync(user);

                    result.Data = new { Success = updateOp.Succeeded, Message = string.Join("\n", updateOp.Errors) };
                }
                else
                {
                    result.Data = new { Success = false, Message = "Invalid User" };
                }
            }

            return result;
        }
        
        public async Task<ActionResult> ChangePassword()
        {
            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.User = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            return PartialView("_ChangePassword", model);
        }

        public async Task<JsonResult> UpdatePassword(UpdatePasswordViewModel model)
        {
            JsonResult result = new JsonResult();

            if (!ModelState.IsValid)
            {
                result.Data = new { Success = false, Message = "Invalid Data" };
            }
            else
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                if (user != null)
                {
                    var updateOp = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    
                    result.Data = new { Success = updateOp.Succeeded, Message = string.Join("\n", updateOp.Errors) };

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                else
                {
                    result.Data = new { Success = false, Message = "Invalid User" };
                }
            }

            return result;
        }

        public async Task<ActionResult> UsersComments(string searchTerm, int? pageNo, int entityID = (int)EntityEnums.Auction)
        {
            var pageSize = 10;
            pageNo = pageNo ?? 1;
            var userID = User.Identity.GetUserId();

            UserCommentsViewModel model = new UserCommentsViewModel();
            model.SearchTerm = searchTerm;

            if (!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);

                if (model.User != null)
                {
                    model.UserComments = service.GetComments(userID, searchTerm, entityID, pageNo, pageSize);

                    if (model.UserComments != null && model.UserComments.Count > 0)
                    {
                        var auctionIDs = model.UserComments.Select(x => x.RecordID).ToList();

                        model.CommentedAuctions = auctionsService.GetAuctionsByIDs(auctionIDs);
                    }

                    var totalCount = service.GetCommentsTotalCount(userID, searchTerm, entityID);

                    model.Pager = new Pager(totalCount, pageNo, pageSize);
                }
            }

            return PartialView("_UsersComments", model);
        }

        [HttpPost]
        public JsonResult DeleteComment(int ID)
        {
            JsonResult result = new JsonResult();

            result.Data = new { Success = service.DeleteComment(ID) };

            return result;
        }

    }
}