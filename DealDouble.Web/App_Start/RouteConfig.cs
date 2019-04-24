using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DealDouble.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SearchAuction",
                url: "search",
                defaults: new { controller = "Home", action = "Search" }
            );

            routes.MapRoute(
                name: "AuctionDetails",
                url: "{category}/auction/{ID}",
                defaults: new { controller = "Auctions", action = "Details" }
            );

            routes.MapRoute(
                name: "UserProfile",
                url: "user/{userID}",
                defaults: new { controller = "Profile", action = "UserProfile" }
            );

            routes.MapRoute(
                name: "UserComments",
                url: "Users/Comments/{userID}",
                defaults: new { controller = "Comments", action = "Index" }
            );

            routes.MapRoute(
                name: "Comments",
                url: "Dashboard/Comments/",
                defaults: new { controller = "Comments", action = "Index" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
