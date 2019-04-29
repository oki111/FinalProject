using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Entities
{
    //ova klasa sadrzi postavke koje su sadrzane za jednu liniju korpe
    //koristi se u klasi Cart
    public class CartLine
    {
        //prva postavka je Produkt objekat
        //pristupa mu se u klasi Cart, EmailOrderProcessor, setuje se samo u klasi Cart
        public Product Product { get; set; }

        //druga je ukupna kolicina ovog Produkta
        //koristi se u klasi Cart, EmailOrderProcessor, setuje se samo u klasi Cart
        public int Quantity { get; set; }
    }
}
