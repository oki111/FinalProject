using SalonVencanica.Domain.Entities;
using SalonVencanica.WebUI.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SalonVencanica.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IModelBinder CartModelBnder { get; private set; }

        //poziva se automatski kada se pokrene web aplikacija
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ovde vezujemo klasu modela korpe 'Cart' za klasu 'CartModelBinder'
            //na ovaj nacin, model korpe 'Cart' postaje dostupan kao argument u akcionim funkcijama kontrolera
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
