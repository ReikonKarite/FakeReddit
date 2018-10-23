using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FakeReddit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "GetAllSubs",
               "r",
               new { Controller = "SubReddits", Action = "Index" });

            routes.MapRoute(
                "GetPostsForSub",
                "r/{subReddit}",
                new { Controller = "Posts", Action="Index", subReddit=UrlParameter.Optional });

            routes.MapRoute(
                "GetActionForSub",
                "r/{subReddit}/{Controller}/{Action}",
                new { Controller = "Posts", Action = "Index", subReddit = UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
