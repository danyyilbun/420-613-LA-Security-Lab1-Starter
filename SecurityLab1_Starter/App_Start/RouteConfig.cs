using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
    name: "Default",
    url: "",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { action = "Contact|About|GenError" }
            );

            routes.MapRoute(
            name: "Inventory",
            url: "Inventory/Index",
            defaults: new { controller = "Inventory", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
          name: "Error",
          url: "Error/ServerError",
          defaults: new { controller = "Error", action = "ServerError", id = UrlParameter.Optional }
      );
            routes.MapRoute(
                name: "CatchAll",
                url: "{*catchall}",
                defaults: new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
            );
        }
    }
}
