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
        [Required(ErrorMessage = "Molimo unesite ime")]
        public string Name { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Molimo unesite ulicu i broj")]
        public string Linija1 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string Linija2 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string Linija3 { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Molimo unesite naziv grada")]
        public string Grad { get; set; }

        //pristupa mu  se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Molimo unesite naziv okruga")]
        public string Okrug { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Molimo unesite naziv drzave")]
        public string Drzava { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public string PTT { get; set; }

        //pristupa mu se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        [Required(ErrorMessage = "Molimo unesite ispravan email")]
        [EmailAddress(ErrorMessage = "Uneta adresa nije ispravna")]
        public string Eposta { get; set; }

        //korisiti se u klasi EmailOrderProcessor, setuje ga korisnik u browseru
        public bool GiftWrap { get; set; }
    }
}
