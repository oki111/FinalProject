using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Entities
{
    //ova klasa sadrzi postavke koje se odnose na podatke vezane za slanje narudzbine a koje unosi korisnik
    //koristi se u klasama EmailOrderProcessor, IOrderProcessor, CartController
    public class ShippingDetails
    {
        //svaka postavka je 'dekorisana' sa atributima Data Anotacije sto za krajnji rezultat ima da korisnik mora da popuni ove podatke u odredjenom formatu
        //ovi atributi se aktiviraju kada se aplikacija pokrene

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string Line2 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string Line3 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Please enter a valid city name")]
        public string City { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Please enter a valid state name")]
        public string State { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Please enter a valid country name")]
        public string Country { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string Zip { get; set; }

        //korisiti se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public bool GiftWrap { get; set; }
    }
}
