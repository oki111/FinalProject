using SalonVencanica.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Controllers
{
    //klasa kontrolera koji se koristi od strane View-a koji pripadju ovom kontroleru
    public class NavController : Controller
    {
        //privatna globalna varijabla koja sadrzi repozitori odnosno bazu
        IProductRepository repository;

        //konstruktor sa injekcijom repozitorija odnosno baze
        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //ovo je akcijska funkcija koja kao ulazne parametre dobija podatke iz browsera na osnovu kojih se selektuju odredjeni podaci iz repozitorija odnosno baze
        //a ka browseru salje objekat tipa 'PartialViewResult' koji sadrzi u sebi listu naziva kategorija selektovanih entitija iz baze
        //ova funkcija se automatski poziva kada korisnik u browseru klikne na link je poziva
        //ova funkcija ima odgovarajuci View koji ima isto ime kao i ova funkcija
        public PartialViewResult Menu(string category = null)
        {
            //send the selected category name dynamicly to the view via view-bag
            ViewBag.SelectedCategory = category;

           
            IEnumerable<string> categories = repository.Products //ovde uzimamo listu kategorija Produkta iz repozitorija odnosno baze
                .Select(x => x.Category) //uzimamo samo kolone koje predstavljaju nazive kategorija produkta
                .Distinct() //uzimamo samo nazive koji su razliciti (u nasem slucaju Men i Women)
                .OrderBy(x => x); //sortiramo nazive uzlazno

            //saljemo vou listu u browser kao 'PartialViewResult' 
            return PartialView(categories);
        }
    }
}