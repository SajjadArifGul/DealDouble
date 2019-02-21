using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDouble.Web.Code.Enums;
using DealDouble.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        private DealDoubleRolesManager _rolesManager;
        private DealDoubleUserManager _userManager;

        public DashboardController()
        {
        }

        public DashboardController(DealDoubleUserManager userManager, DealDoubleRolesManager rolesManager)
        {
            UserManager = userManager;
            RolesManager = rolesManager;
        }

        public DealDoubleRolesManager RolesManager
        {
            get
            {
                return _rolesManager ?? HttpContext.GetOwinContext().Get<DealDoubleRolesManager>();
            }
            private set
            {
                _rolesManager = value;
            }
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

        DashboardService service = new DashboardService();

        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            model.Page = Pages.Dashboard;

            model.UserCount = service.GetUserCount();
            model.AuctionsCount = service.GetAuctionCount();
            model.BidsCount = service.GetBidsCount();

            return View(model);
        }

        public ActionResult Users(string userSearch, int? pageNo)
        {
            pageNo = pageNo ?? 1;
            var pageSize = 10;

            UsersViewModel model = new UsersViewModel();
            model.Page = Pages.Users;
            model.UserSearch = userSearch;

            var allUsers = UserManager.Users;

            if (!string.IsNullOrEmpty(userSearch))
            {
                allUsers = allUsers.Where(x => x.UserName.ToLower().Contains(userSearch.ToLower()));
            }

            var skipCount = (pageNo.Value - 1) * pageSize;

            model.Users = allUsers.OrderBy(x => x.UserName).Skip(skipCount).Take(pageSize).ToList();

            model.Roles = RolesManager.Roles.ToList();

            model.Pager = new Pager(allUsers.Count(), pageNo, pageSize);

            if(Request.IsAjaxRequest())
            {
                return PartialView("_UserListing", model);
            }
            else return View(model);
        }
    }
}