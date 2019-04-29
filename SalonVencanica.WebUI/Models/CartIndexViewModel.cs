using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonVencanica.WebUI.Models
{
    //ovak klasa sadrzi model korpe i web-adresu koju vraca korpa
    //koristi se u klasama CartCOntroller i CartIndexViewModel
    public class CartIndexViewModel
    {
        //model korpe
        //setuje se u klasi CartController
        public Cart Cart { get; set; }

        //adresa vracena od strane korpe
        //setuje se u klasi CartController
        public string ReturnUrl { get; set; }
    }
}