using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class BidsService
    {

        public List<Bid> SearchBids(string userID, int? auctionID, int? pageNo, int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            var bids = context.Bids.AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                bids = bids.Where(x => x.UserID == userID);
            }

            if (auctionID.HasValue && auctionID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.ID == auctionID.Value);
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return bids.OrderByDescending(x => x.ID).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetBidsCount(string userID, int? auctionID)
        {
            DealDoubleContext context = new DealDoubleContext();

            var bids = context.Bids.AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                bids = bids.Where(x => x.UserID == userID);
            }

            if (auctionID.HasValue && auctionID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.ID == auctionID.Value);
            }

            return bids.Count();
        }

        public Bid GetBidByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Bids.Find(ID);
        }

        public bool AddBid(Bid bid)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Bids.Add(bid);

            return context.SaveChanges() > 0;
        }

        public bool DeleteBid(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            var bid = context.Bids.Find(ID);

            context.Entry(bid).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
