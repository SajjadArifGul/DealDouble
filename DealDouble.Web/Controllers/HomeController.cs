using DealDouble.Entities;
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
        AuctionsService auctionsService = new AuctionsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            PageViewModel model = new PageViewModel();

            model.PageTitle = "Home Page";
            model.PageDescription = "This is Home Page";

            return View(model);
        }

        [OutputCache(Duration = 5000)]
        public ActionResult HomeSliders()
        {
            HomeSlidersViewModel model = new HomeSlidersViewModel();

            ConfigurationsService configurationsService = new ConfigurationsService();

            model.SlidersConfigurations = configurationsService.GetConfigurationsByType((int)ConfigurationType.HomeSliders);

            return PartialView("_HomeSliders", model);
        }

        public ActionResult Search(int? categoryID, string q, int? pageNo, bool isPartial = false)
        {
            var pageSize = 6;

            AuctionsListingViewModel model = new AuctionsListingViewModel();
            model.PageTitle = "Search Auctions";
            model.PageDescription = "Search Latest Auctions on DealDouble";

            model.CategoryID = categoryID;
            model.SearchTerm = q;
            model.isPartial = isPartial;

            model.Categories = categoriesService.GetAllCategories();
            model.Auctions = auctionsService.SearchAuctions(model.CategoryID, model.SearchTerm, pageNo, pageSize);

            var totalAuctions = auctionsService.GetAuctionCount(categoryID, q);

            model.Pager = new Pager(totalAuctions, pageNo, pageSize);

            if(model.isPartial)
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}