using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDouble.Web.Code.Enums;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            PageViewModel model = new PageViewModel();

            model.Page = Pages.Dashboard;
            return View(model);
        }
    }
}