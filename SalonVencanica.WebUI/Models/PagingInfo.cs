using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonVencanica.WebUI.Models
{
    //ova klasa sadrzi postavke za stranice koje sadrze spisak Produkt modela
    //koristi se u klasama ProductsListViewModel, PagingHelpers, ProductController
    public class PagingInfo
    {
        //ukupan broj modela Produkt u tabeli baze
        //setuje se u klasi ProductController
        public int TotalItems { get; set; }

        //broj prikazanih Produkt modela po stranici
        //setuje se u klasi ProductController
        public int ItemsPerPage { get; set; }

        //trenutna stranica liste Produkt modela
        //setuje se u klasi ProductController i PagingHelpers
        public int CurrentPage { get; set; }

        //ukupan broj stranica koje prikazuju listu Produkt modela
        //pristupa mu se u klasi PagingHelpers
        public int TotalPages
        {
            get
            {
                //jednostavno podelimo ukupan broj modela u bazi sa brojem po stranici
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}