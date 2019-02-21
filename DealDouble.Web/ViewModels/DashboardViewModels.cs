using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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
        public List<DealDoubleUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string UserSearch { get; internal set; }

        public Pager Pager { get; set; }
    }
}