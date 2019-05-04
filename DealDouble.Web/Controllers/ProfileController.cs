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

        public async Task<ActionResult> ChangeAvatar()
        {
            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.User = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            return PartialView("_ChangeAvatar", model);
        }

        public async Task<JsonResult> UpdateAvatar(int pictureID)
        {
            JsonResult result = new JsonResult();

            if (pictureID <= 0)
            {
                result.Data = new { Success = false, Message = "Invalid Data" };
            }
            else
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                if (user != null)
                {
                    user.PictureID = pictureID;

                    var updateOp = await UserManager.UpdateAsync(user);

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

        public ActionResult UserProfile(string userID)
        {
            if(userID == User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Profile");
            }

            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.User = UserManager.FindById(userID);

            if (model.User != null)
            {
                model.PageTitle = string.Format("User: {0}", model.User.FullName);
                model.PageDescription = string.Format("User profile of {0}", model.User.FullName);

                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        
        public ActionResult UsersDetailsView(string userID)
        {
            ProfileDetailsViewModel model = new ProfileDetailsViewModel();

            model.User = UserManager.FindById(userID);

            return PartialView("_UsersDetailsView", model);
        }
    }
}