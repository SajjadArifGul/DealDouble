using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class CommentsViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public DealDoubleUser User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Auction> CommentedAuctions { get; set; }
        public Pager Pager { get; set; }
    }
}