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
        public int AuctionsCount { get; set; }
        public int BidsCount { get; set; }
        public int CommentsCount { get; set; }
        public int CategoriesCount { get; set; }
        public int UserCount { get; set; }
        public int RolesCount { get; set; }
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

        public string ID { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
    
    public class UserRolesViewModel : PageViewModel
    {
        public List<IdentityRole> AvailableRoles { get; set; }
        public List<IdentityRole> UserRoles { get; set; }
        public DealDoubleUser User { get; internal set; }
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

    public class RoleDetailsViewModel : PageViewModel
    {
        public IdentityRole Role { get; set; }

        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class RoleUsersViewModel : PageViewModel
    {
        public List<DealDoubleUser> RoleUsers { get; set; }

        public Pager Pager { get; set; }
        public string RoleID { get; internal set; }
    }


    public class UserCommentsViewModel : PageViewModel
    {
        public List<Comment> UserComments { get; set; }
        public List<Auction> CommentedAuctions { get; set; }
        public DealDoubleUser User { get; internal set; }
    }
}