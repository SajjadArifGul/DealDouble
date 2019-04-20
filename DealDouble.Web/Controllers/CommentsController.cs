using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity;
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
        CommentsService commentsService = new CommentsService();
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

            model.Comments = commentsService.GetComments(userID, searchTerm, entityID, pageNo, pageSize);

            if (model.Comments != null && model.Comments.Count > 0)
            {
                var auctionIDs = model.Comments.Select(x => x.RecordID).ToList();

                model.CommentedAuctions = auctionsService.GetAuctionsByIDs(auctionIDs);
            }

            var totalCount = commentsService.GetCommentsTotalCount(userID, searchTerm, entityID);

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
        public JsonResult LeaveComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();

            try
            {
                var comment = new Comment();
                comment.Text = model.Text;
                comment.Rating = model.Rating;
                comment.EntityID = model.EntityID;
                comment.RecordID = model.RecordID;
                comment.UserID = User.Identity.GetUserId();
                comment.TimeStamp = DateTime.Now;

                var res = commentsService.AddComment(comment);

                result.Data = new { Success = res };
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }

            return result;
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            JsonResult result = new JsonResult();

            var comment = commentsService.GetComment(ID);

            if (comment != null && User.Identity.IsAuthenticated && (User.IsInRole("Administrator") || comment.UserID == User.Identity.GetUserId()))
            {
                result.Data = new { Success = commentsService.DeleteComment(comment), Message = "" };
            }
            else
            {
                result.Data = new { Success = false, Message = "You are Unauthorized to perform this action." };
            }

            return result;
        }
    }
}