using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Binders
{
    //ova klasa nasledjuje model binder i implementira svoju verziju ove bazne klase
    //registruje se u klasi Global.asax.cs
    public class CartModelBinder : IModelBinder
    {
        //privatna globalna varijabla
        const string sessionKey = "Cart";

        //ova funkcija omogucava pristup korpi iz sesije ukoliko u njoj postoji a ukoliko ne postoji, onda stavlja novu korpu u sesiju
        //na ovaj nacin, ne moramo da pristupamo sesiji direktno u kontroleru, vec model korpe mozemo poslati direktno u akcione funkcije kontrolera
        //poziva se automatski kada kontroler (CartController) koji koristi korpu (Cart) vraca konteks the korpe
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //za pocetak lokalna varijabla 'korpa' je null
            Cart cart = null;

            //ako je sesija validna
            if(controllerContext.HttpContext.Session != null)
            {
                //onda iz te sesije na osnovu naziva uzimamo korpu (ukoliko postoji) i stavljamo je u lokalnu varijablu
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            //ako prethodno nije bilo korpe u sesiji, onda je lokalna varijabla korpe i dalje null
            if(cart == null)
            {
                //prvo instanciramo objekat korpe
                cart = new Cart();

                //ako je sesija validna
                if (controllerContext.HttpContext.Session != null)
                {
                    //upisujemo upravo instancirani objekat korpe u sesiju
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }

                
            }

            //vracamo korpu ka kontroleru
            return cart;
        }
    }
}