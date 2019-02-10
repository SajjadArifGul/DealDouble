using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDouble.Web.Code.Enums;
using DealDouble.Services;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
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
    }
}