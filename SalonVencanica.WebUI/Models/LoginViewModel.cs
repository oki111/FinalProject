using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonVencanica.WebUI.Models
{
    //ova klasa sadrzi korsinicko ime i sifru za ulogovanog administratora
    //koristi u klasi AccountController
    public class LoginViewModel
    {
        //ime administratora
        //pristupa mu se u klasi AccountController
        //setuje ga korisnik u browseru
        [Required(ErrorMessage = "Korisnicko ime je obavezno")]
        public string UserName { get; set; }

        //sifra administratora
        //pristupa mu se u klasi AccountController
        //setuje ga korisnik u browseru
        [Required(ErrorMessage = "Sifra je obavezna")]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}