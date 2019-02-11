using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionsService service = new AuctionsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index(int? categoryID, string searchTerm, int? pageNo)
        {
            AuctionsViewModel model = new AuctionsViewModel();

            model.PageTitle = "Home Page";
            model.PageDescription = "This is Home Page";

            model.CategoryID = categoryID;
            model.SearchTerm = searchTerm;

            model.Categories = categoriesService.GetAllCategories();
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your home application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}