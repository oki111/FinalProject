using SalonVencanica.Domain.Abstract;
using SalonVencanica.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Controllers
{
    //klasa kontrolera koji se koristi od strane View-a koji pripadju ovom kontroleru
    public class ProductController : Controller
    {
        //privatna globalna varijabla koja sadrzi repozitori odnosno bazu
        readonly IProductRepository repo;

        //privatna globalna varijabla koja definise koliko Produkt artikala ce se prikazivati po stranici
        int pageSize = 4;

        //konstruktor sa injekcijom repozitorija odnosno baze
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        //ovo je akcijska funkcija koja kao ulazne parametre dobija podatke iz browsera na osnovu kojih se selektuju odredjeni podaci iz repozitorija odnosno baze
        //a ka browseru salje objekat tipa 'ViewResult' koji sadrzi u sebi model tipa 'ProductsListViewModel' a koji dalje sadrzi postavke sa vrednostima iz baze
        //ova funkcija se automatski poziva kada korisnik u browseru klikne na link je poziva
        //ova funkcija ima odgovarajuci View koji ima isto ime kao i ova funkcija
        public ViewResult List(string category, int page = 1)
        {
            //lokalna instanca modela ProductsListViewModel i dodela vrednosti njegovih clanova
            ProductsListViewModel model = new ProductsListViewModel()
            {
                //Produkt listi iz modela dodeljujemo vrednost liste enitija Produkt iz repozitorija odnosno baze
                Products = repo.Products
                .Where(p => category == null || p.Category == category) //pri tom odabitamo samo entitije Produkt kod kojih se kategorija poklapa sa kategorijom koju je odabrao krajnji korisnik u browseru
                .OrderBy(p => p.ProductId) //zatim ih sortiramo uzlazno po Id-u
                .Skip((page - 1) * pageSize) //pri tom preskacemo sve entitije iz baze koji su sortirani pre odredjenog indeksa u bazi a koji se dobija na osnovu ove kalkulacije
                .Take(pageSize), //konacno, uzimamo samo cetiri entitja, pocevsi od indeksa u bazi koji je izracunat na prethodnoj liniji koda

                //instanca objekta PagingInfo koji je clan modela ProductsListViewModel i dodela vrednosti njegovih clanova
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page, //dodeljujemo trenutni broj strane koji dolazi iz browsera
                    ItemsPerPage = pageSize, //dodeljujemo predefinisani broj modela po stranici

                    //dodeljujemo ukupan broj modela u ProductsListViewModel na osnovu naziva kategorije koju je korisnik selektovao u browseru
                    //ukoliko je naziv kategorije 'null' znaci da nijedna kategorija nije selektovana, pa stoga brojimo sve Produkt modele
                    //ukoliko je naziv kategorije 'men' ili 'women' onda brojimo samo modele iz ove kategorije
                    TotalItems = category == null ? repo.Products.Count() : repo.Products.Where(p => p.Category == category).Count()

                },

                //dodeljujemo vrednost selektovane kategorije iz browsera
                CurrentCategory = category
            };

            //konacno saljemo model u kontekstu View-a ka browseru
            return View(model);
        }
    }
}