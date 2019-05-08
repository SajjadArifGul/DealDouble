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

        public ActionResult Index(string userID, int? auctionID, int? pageNo)
        {
            BidsListingViewModel model = new BidsListingViewModel();

            model.PageTitle = "Bids";
            model.PageDescription = "Bids Listing Page";

            model.UserID = userID;
            model.AuctionID = auctionID;
            model.PageNo = pageNo ?? 1;
            
            return View(model);
        }

        public ActionResult Listing(string userID, int? auctionID, int? pageNo)
        {
            var pageSize = 10;

            BidsListingViewModel model = new BidsListingViewModel();

            model.Bids = bidsService.SearchBids(userID, auctionID, pageNo, pageSize);
            var totalBids = bidsService.GetBidsCount(userID, auctionID);

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

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            JsonResult result = new JsonResult();

            var bid = bidsService.GetBidByID(ID);
            if (bid != null)
            {
                var bidResult = bidsService.DeleteBid(ID);

                if (bidResult)
                {
                    result.Data = new { Success = bidResult };
                }
                else
                    result.Data = new { Success = false, Message = "Unable to delete bid." };
            }
            else
            {
                result.Data = new { Success = false, Message = "Bid not found." };
            }

            return result;
        }
    }
}