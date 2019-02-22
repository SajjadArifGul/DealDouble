using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealDouble.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DealDouble.Web.ViewModels
{
    public class DashboardViewModel : PageViewModel
    {
        public int UserCount { get; set; }
        public int AuctionsCount { get; set; }
        public int BidsCount { get; set; }
    }
    
    public class UsersViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public string RoleID { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public int? PageNo { get; internal set; }
    }
    
    public class UsersListingViewModel : PageViewModel
    {
        public List<DealDoubleUser> Users { get; set; }
        public Pager Pager { get; set; }
        public string RoleID { get; internal set; }
        public string SearchTerm { get; internal set; }
    }
}