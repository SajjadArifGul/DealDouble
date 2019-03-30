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
        public int? PageNo { get; set; }
    }
    
    public class UsersListingViewModel : PageViewModel
    {
        public List<DealDoubleUser> Users { get; set; }
        public Pager Pager { get; set; }
        public string RoleID { get; set; }
        public string SearchTerm { get; set; }
    }
    
    public class UserDetailsViewModel : PageViewModel
    {
        public DealDoubleUser User { get; set; }
    }

    public class UserRolesViewModel : PageViewModel
    {
        public List<IdentityRole> AvailableRoles { get; set; }
        public List<IdentityRole> UserRoles { get; set; }
    }

    public class RolesViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public int? PageNo { get; set; }
    }

    public class RolesListingViewModel : PageViewModel
    {
        public List<IdentityRole> Roles { get; set; }
        public Pager Pager { get; set; }
        public string SearchTerm { get; set; }
    }
}