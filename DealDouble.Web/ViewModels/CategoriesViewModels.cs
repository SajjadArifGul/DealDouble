using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class CategoriesViewModel : PageViewModel
    {
        public List<Category> AllCategories { get; set; }
    }

    public class CategoriesListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }

        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
        public int PageNo { get; set; }
        public List<Category> ParentCategories { get; set; }
        public int? ParentCategoryID { get; set; }
    }

    public class CategoryDetailsViewModel : PageViewModel
    {
        public Category Category { get; set; }
    }

    public class CategoryViewModel : PageViewModel
    {
        public int ParentCategoryID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Auction> Auctions { get; set; }

        public List<Category> Categories { get; set; }
        public bool isFeatured { get; set; }
    }
}