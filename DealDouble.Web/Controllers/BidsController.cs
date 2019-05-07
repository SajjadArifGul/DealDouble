using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class BidsController : Controller
    {
        BidsService bidsService = new BidsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index(int? categoryID, int? auctionID, string searchTerm, int? pageNo)
        {
            BidsListingViewModel model = new BidsListingViewModel();

            model.PageTitle = "Bids";
            model.PageDescription = "Bids Listing Page";

            model.CategoryID = categoryID;
            model.AuctionID = auctionID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo ?? 1;

            model.Categories = categoriesService.GetAllParentCategories();

            return View(model);
        }

        public ActionResult Listing(int? categoryID, int? auctionID, string searchTerm, int? pageNo)
        {
            var pageSize = 10;

            BidsListingViewModel model = new BidsListingViewModel();

            model.Bids = bidsService.SearchBids(categoryID, auctionID, searchTerm, pageNo, pageSize);
            var totalBids = bidsService.GetBidsCount(categoryID, auctionID, searchTerm);

            model.Pager = new Pager(totalBids, pageNo, pageSize);

            return PartialView("_Listing", model);
        }

        [HttpPost]
        public JsonResult Bid(int ID)
        {
            JsonResult result = new JsonResult();

            if (User.Identity.IsAuthenticated)
            {
                Bid bid = new Bid();

                bid.AuctionID = ID;
                bid.UserID = User.Identity.GetUserId();
                bid.Timestamp = DateTime.Now;
                bid.BidAmount = 10;

                var bidResult = bidsService.AddBid(bid);

                if(bidResult)
                {
                    result.Data = new { Success = true };
                }
                else
                    result.Data = new { Success = false, Message = "Unable to add bid to auction." };
            }
            else
            {
                result.Data = new { Success = false, Message = "User needs to login for bids." };
            }

            return result;
        }
    }
}