using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SalonVencanica.WebUI
{
    //u ovoj klasi se rade postavke za konfiguraciju putanja za akcije kontrolera
    //postavke koje se ovde nalaze su preuzete sa stackoverflow i ne pamte se
    //ova klasa se registruje u klasi Global.asax.cs
    public class RouteConfig
    {
        //poziva se u klasi Global.asax.cs
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
              new
              {
                  controller = "Product",
                  action = "List",
                  category = (string)null,
                  page = 1
              });

            routes.MapRoute(null, "Page{page}",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null
                },
                new { page = @"\d+" });

            routes.MapRoute(null, "{category}",
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                });

            routes.MapRoute(null, "{category}/Page{page}",
                new
                {
                    controller = "Product",
                    action = "List"
                },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
            
        }
    }
}
