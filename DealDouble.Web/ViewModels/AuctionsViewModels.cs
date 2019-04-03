using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.ViewModels
{
    public class AuctionsViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }

        public int? CategoryID { get; set; }
        public string SearchTerm { get; set; }        
    }

    public class AuctionsListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Auction> Auctions { get; set; }

        public int? CategoryID { get; set; }
        public string SearchTerm { get; set; }

        public bool isPartial { get; set; }

        public Pager Pager { get; set; }
        public int PageNo { get; set; }
    }

    public class AuctionDetailsViewModel : CommentablePageViewModel
    {
        public Auction Auction { get; set; }
        
        public decimal BidsAmount { get; set; }
        public DealDoubleUser LatestBidder { get; set; }
    }
    
    public class CreateAuctionViewModel : PageViewModel
    {
        public int ID { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public int CategoryID { get; set; }
        
        [Required]
        [MinLength(20)]
        [MaxLength(200)]
        public string Summary { get; set; }

        [Required]
        [MinLength(20)]
        [AllowHtml]
        public string Description { get; set; }
        
        [Required]
        [Range(1, 10000000)]
        public decimal ActualAmount { get; set; }

        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }

        public string AuctionPictures { get; set; }

        public List<Category> Categories { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
    }
}