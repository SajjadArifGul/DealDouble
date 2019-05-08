using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class BidsListingViewModel : PageViewModel
    {
        public List<Bid> Bids { get; set; }

        public string UserID { get; set; }
        public int? AuctionID { get; set; }

        public bool isPartial { get; set; }

        public Pager Pager { get; set; }
        public int PageNo { get; set; }
    }
}