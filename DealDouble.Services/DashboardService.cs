using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class DashboardService
    {
        public int GetAuctionCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Auctions.Count();
        }
        public int GetBidsCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Bids.Count();
        }
        public int GetCommentsCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Comments.Count();
        }
        public int GetUserCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Users.Count();
        }
        public int GetRolesCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Roles.Count();
        }
        public int GetCategoriesCount()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.Count();
        }

        public List<Comment> GetComments(string userID, string searchTerm, int entityID, int? pageNo, int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            var comments = context.Comments.Where(x => x.EntityID == entityID)
                                   .AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                comments = comments.Where(x => x.UserID == userID);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                comments = comments.Where(x => x.Text.ToLower().Contains(searchTerm.ToLower()));
            }

            return comments.OrderByDescending(x => x.TimeStamp)
                           .Skip(skipCount)
                           .Take(pageSize)
                           .ToList();
        }

        public int GetCommentsTotalCount(string userID, string searchTerm, int entityID)
        {
            DealDoubleContext context = new DealDoubleContext();
            
            var comments = context.Comments.Where(x => x.EntityID == entityID)
                                   .AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                comments = comments.Where(x => x.UserID == userID);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                comments = comments.Where(x => x.Text.ToLower().Contains(searchTerm.ToLower()));
            }

            return comments.Count();
        }

        public bool DeleteComment(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();
            
            var comment = context.Comments.Find(ID);

            if(comment != null)
            {
                context.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }

            return false;
        }

    }
}
