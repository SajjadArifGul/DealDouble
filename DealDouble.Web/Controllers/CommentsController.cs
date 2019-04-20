using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class CommentsController : Controller
    {
        DashboardService dashboardService = new DashboardService();
        AuctionsService auctionsService = new AuctionsService();

        private DealDoubleUserManager _userManager;
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

        public async Task<ActionResult> Index(string userID, string searchTerm, int? pageNo, int entityID = (int)EntityEnums.Auction, bool isPartial = false)
        {
            var pageSize = 10;
            pageNo = pageNo ?? 1;

            CommentsViewModel model = new CommentsViewModel();
            model.SearchTerm = searchTerm;

            if(!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);
            }

            model.Comments = dashboardService.GetComments(userID, searchTerm, entityID, pageNo, pageSize);

            if (model.Comments != null && model.Comments.Count > 0)
            {
                var auctionIDs = model.Comments.Select(x => x.RecordID).ToList();

                model.CommentedAuctions = auctionsService.GetAuctionsByIDs(auctionIDs);
            }

            var totalCount = dashboardService.GetCommentsTotalCount(userID, searchTerm, entityID);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            if(Request.IsAjaxRequest() || isPartial)
            {
                return PartialView("_UserComments", model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            JsonResult result = new JsonResult();

            result.Data = new { Success = dashboardService.DeleteComment(ID) };

            return result;
        }
    }
}