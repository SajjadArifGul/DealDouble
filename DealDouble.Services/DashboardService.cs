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

        public List<Comment> GetCommentsByUser(string userID, int entityID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Comments.Where(x => x.UserID == userID).Where(x=>x.EntityID == entityID).OrderByDescending(x => x.TimeStamp).ToList();
        }
    }
}
