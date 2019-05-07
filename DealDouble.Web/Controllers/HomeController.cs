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

        public ActionResult Search(string category, int? categoryID, string q, int? pageNo, bool isPartial = false)
        {
            var pageSize = 6;

            AuctionsListingViewModel model = new AuctionsListingViewModel();
            model.PageTitle = "Search Auctions";
            model.PageDescription = "Search Latest Auctions on DealDouble";

            model.CategoryID = categoryID;
            model.CategoryName = category;

            var selectedCategory = model.CategoryID.HasValue ? categoriesService.GetCategoryByID(model.CategoryID.Value) :
                                   !string.IsNullOrEmpty(model.CategoryName) ? categoriesService.GetCategoryByName(model.CategoryName) : null;

            if (model.CategoryID.HasValue || !string.IsNullOrEmpty(model.CategoryName)) //if category wise auction searching
            {
                if (selectedCategory == null) return HttpNotFound();
                else
                {
                    model.CategoryID = selectedCategory.ID;
                    model.CategoryName = selectedCategory.SanitizedName;
                }
            }

            model.SearchTerm = q;
            model.isPartial = isPartial;

            model.Categories = categoriesService.GetAllCategories();
            model.Auctions = auctionsService.SearchAuctions(model.CategoryID, model.SearchTerm, pageNo, pageSize);

            var totalAuctions = auctionsService.GetAuctionCount(model.CategoryID, q);

            model.Pager = new Pager(totalAuctions, pageNo, pageSize);

            if (model.isPartial)
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