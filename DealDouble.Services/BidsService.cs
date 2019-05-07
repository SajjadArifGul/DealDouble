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

        public List<Bid> SearchBids(int? categoryID, int? auctionID, string searchTerm, int? pageNo, int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            var bids = context.Bids.AsQueryable();

            if (categoryID.HasValue && categoryID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.CategoryID == categoryID.Value);
            }

            if (auctionID.HasValue && auctionID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.ID == auctionID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                bids = bids.Where(x => x.Auction.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return bids.OrderByDescending(x => x.ID).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetBidsCount(int? categoryID, int? auctionID, string searchTerm)
        {
            DealDoubleContext context = new DealDoubleContext();

            var bids = context.Bids.AsQueryable();

            if (categoryID.HasValue && categoryID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.CategoryID == categoryID.Value);
            }

            if (auctionID.HasValue && auctionID.Value > 0)
            {
                bids = bids.Where(x => x.Auction.ID == auctionID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                bids = bids.Where(x => x.Auction.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            return bids.Count();
        }

        public bool AddBid(Bid bid)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Bids.Add(bid);

            return context.SaveChanges() > 0;
        }        
    }
}
