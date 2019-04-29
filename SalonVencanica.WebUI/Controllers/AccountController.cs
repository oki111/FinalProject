using SalonVencanica.Domain.Abstract;
using SalonVencanica.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SalonVencanica.WebUI.Controllers
{
    //klasa kontrolera koji se koristi od strane View-a koji pripadju ovom kontroleru
    //dekorisana je sa atributom 'Authorize' zbog toga sto View-i koji koriste ovaj kontroler mora da budu zasticen da ne moze svako da im pristupi
    [Authorize]
    public class AccountController : Controller
    {
        //privatna globalna varijabla koja sadrzi repozitori odnosno bazu
        IAuthentication authentication;

        //konstruktor sa injekcijom repozitorija odnosno baze
        public AccountController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde se unose podaci za logovanje
        //dekorisan je sa atributom 'AllowAnonymous' da bi korisnik koji jos nije ulogovan mogao uposte da pristup stranici za unosenje podataka
        [AllowAnonymous]
        public ActionResult Login()
        {
            //vracamo ka browseru view za logovanje
            return View();
        }

        //ova 'http-get' funkcija redirektuje korisnika na View koji se dobija nakon uspesnog logovanja administratora
        //dekorisan je sa atributom 'AllowAnonymous' da bi korisnik koji jos nije ulogovan mogao uposte da pristup stranici za unosenje podataka ukoliko nisu uneti tacni podaci
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //ako je stanje modela validno
            //ModelState je Dictionary objekat cija definicija se nalazi u klasi osnove a koju nasledjuje ovaj kontroler
            if (ModelState.IsValid)
            {
                //ako su uneti username i sifra tacni odnosno postoje u bazi
                if (authentication.Authenticate(model.UserName, model.Password))
                {
                    //setujemo kuki koji cuva username od administratora na koriscenom browseru
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    //vracamo ka browseru View koji se nalazi pod adresom 'Admin/Index'
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin") );
                }

                //ako uneti username i sifra nisu tacni odnosno ne postoje u bazi
                else
                {
                    //dodajemo poruku o gresci  u stanje modela
                    ModelState.AddModelError("", "Incorrect username or password");

                    //vracamo ka browseru view za logovanje 
                    return View();
                }
            }

            //ako stanje modela nije validno
            else
            {
                //vracamo ka browseru view za logovanje 
                return View();
            }

            
        }

        //ova funkcija se koristi da se admin izloguje sa sajta
        public ActionResult Logout()
        {
            //pozivamo funkciju iz ASP frejmvorka koja se koristi za izlogovanje
            FormsAuthentication.SignOut();

            //vracamo ka browseru View koji se koristi za logovanje
            return RedirectToAction("Index", "Admin");
        }

        //change password
        //forget password
    }
}