using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Shared.Extensions;
using DealDouble.Web.Code.Enums;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        
        public ActionResult Index(int? parentCategoryID, string searchTerm, int? pageNo)
        {
            CategoriesListingViewModel model = new CategoriesListingViewModel();

            model.Page = Pages.Categories;
            model.PageTitle = "Categories";
            model.PageDescription = "Categories Listing Page";

            model.ParentCategoryID = parentCategoryID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo ?? 1;

            model.ParentCategories = categoriesService.GetAllParentCategories();

            return View(model);
        }

        public ActionResult Listing(int? parentCategoryID, string searchTerm, int? pageNo)
        {
            var pageSize = 10;

            CategoriesListingViewModel model = new CategoriesListingViewModel();
            
            model.Categories = categoriesService.SearchCategories(parentCategoryID, searchTerm, pageNo, pageSize);
            var totalCategories = categoriesService.GetCategoriesCount(parentCategoryID, searchTerm);

            model.Pager = new Pager(totalCategories, pageNo, pageSize);

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();

            model.Categories = categoriesService.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            Category category = new Category();

            if(model.ParentCategoryID > 0)
            {
                category.ParentCategoryID = model.ParentCategoryID;
            }

            category.Name = model.Name;
            category.SanitizedName = model.Name.SanitizeLowerString();
            category.Description = model.Description;
            category.isFeatured = model.isFeatured;

            categoriesService.SaveCategory(category);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CategoryViewModel model = new CategoryViewModel();

            var category = categoriesService.GetCategoryByID(ID);

            model.ParentCategoryID = category.ParentCategoryID.HasValue ? category.ParentCategoryID.Value : 0;
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            model.isFeatured = category.isFeatured;

            model.Categories = categoriesService.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            Category category = new Category();

            if (model.ParentCategoryID > 0)
            {
                category.ParentCategoryID = model.ParentCategoryID;
            }

            category.ID = model.ID;
            category.Name = model.Name;
            category.SanitizedName = model.Name.SanitizeLowerString();
            category.Description = model.Description;
            category.isFeatured = model.isFeatured;

            categoriesService.UpdateCategory(category);

            return RedirectToAction("Listing");
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoriesService.DeleteCategory(category);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            CategoryDetailsViewModel model = new CategoryDetailsViewModel();

            model.Category = categoriesService.GetCategoryByID(ID);

            model.PageTitle = "Category Details: " + model.Category.Name;
            model.PageDescription = model.Category.Description.Substring(0, 10);

            return View(model);
        }

        [OutputCache(Duration = 1000, VaryByParam = "none")]
        public ActionResult FeaturedCategories()
        {
            return PartialView("_FeaturedCategoriesMenuItem", categoriesService.GetFeaturedCategories());
        }

    }
}