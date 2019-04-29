using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonVencanica.WebUI.Models
{
    //ova klasa sadrzi listu produkt modela iz baze, model za informacije o stranici i trenutno odabranu kategoriju Produkta
    //koristi se u klasi ProductController
    public class ProductsListViewModel
    {
        //sadrzi listu Produkt modela iz repozitorija odnosno baze
        //setuje se u klasi ProductController
        public IEnumerable<Product> Products { get; set; }

        //setuje se u klasi ProductController
        public PagingInfo PagingInfo { get; set; }
        
        //setuje se u klasi ProductController
        public string CurrentCategory { get; set; }
    }
}