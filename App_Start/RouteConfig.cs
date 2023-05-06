using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Лабораторная_работа___5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default3",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default4",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Delete", id = UrlParameter.Optional }
            );
        }
    }
}
