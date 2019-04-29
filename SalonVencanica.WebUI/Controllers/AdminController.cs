using SalonVencanica.Domain.Abstract;
using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Controllers
{
    //klasa kontrolera koji se koristi od strane View-a koji pripadju ovom kontroleru
    //dekorisana je sa atributom 'Authorize' zbog toga sto View-i koji koriste ovaj kontroler mora da budu zasticen da ne moze svako da im pristupi
    [Authorize]
    public class AdminController : Controller
    {
        //privatna globalna varijabla koja sadrzi repozitori odnosno bazu
        IProductRepository repository;

        //konstruktor sa injekcijom repozitorija odnosno baze
        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde ce nakon uspesnog logovanja administratora biti prikazana lista Produkt-a iz baze
        public ActionResult Index()
        {
            //vracamo ka browseru view koji ce da sadrzi spisak Produkt-a iz baze
            return View(repository.Products);
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde se unose podaci za novi Produkt koji administrator unosi u bazu
        public ViewResult Create()
        {
            //vracamo ka browseru view na kom se unose podaci novog Produkta
            return View(new Product());
        }

        //ova 'http-post' funkcija redirektuje korisnika na View gde ce biti prikazani Produkt-i iz baze nakon unosa novog Produkta
        //ova funkcija dakle upisuje u bazu podatke novog Produkt-a koji je unet preko browser-a od strane administratora
        [HttpPost]
        public ActionResult Create(Product product)
        {
            //ako je stanje modela validno
            if (ModelState.IsValid)
            {
                //upisujemo novi Produkt model u bazu
                repository.SaveProduct(product);

                //upisujemo u Dictionary poruku da je Produkt uspesno sacuvan u bazi
                TempData["message"] = string.Format("{0} Has been saved", product.Name);

                //vracamo ka browseru view koji ce da sadrzi azuriran spisak Produkt-a iz baze
                return RedirectToAction("Index");
            }

            //ako stanje modela nije validno 
            else
            {
                //ostajemo na View gde se unose podaci za novi Produkt
                return View(product);
            }
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde se mogu promeniti podaci odredjenog Produkt-a u bazi
        public ViewResult Edit(int productId)
        {
            //prvo pronalazimo u bazi Produkt model na osnovu productId-a koji je korisnik odabrao preko browser-a
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            //i onda odlazimo na View gde se menjaju podaci Produkt-a
            return View(product);
        }

        //ova 'http-post' funkcija redirektuje korisnika na View gde ce biti prikazani Produkt-i iz baze nakon uspesne izmene podataka odredjenog Produkta
        //ova funkcija dakle upisuje u bazu nove podatke odredjenog Produkt-a koji su uneti preko browser-a od strane administratora
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            //ako je stanje modela validno
            if (ModelState.IsValid)
            {
                //upisujemo izmenjene podatke odabranog Produkt-a u bazu
                repository.SaveProduct(product);

                //upisujemo u Dictionary poruku da je Produkt uspesno sacuvan u bazi
                TempData["message"] = string.Format("{0} Has been saved", product.Name);

                //vracamo ka browseru view koji ce da sadrzi azuriran spisak Produkt-a iz baze
                return RedirectToAction("Index");
            }

            //ako stanje modela nije validno
            else
            {
                //ostajemo na View gde se menjaju podaci odabranog Produkt-a
                return View(product);
            }
        }

        //ova 'http-post' funkcija redirektuje korisnika na View gde ce biti prikazani Produkt-i iz baze nakon uspesnog brisanja odabranog Produkta
        //ova funkcija dakle brise i baze odredjeni Produkt koji je odabran od strane administratora
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            //pronadjemo i brisemo u bazi Produkt koji je administrator odabrao za brisanje na osnovu ProductId-a
            Product deleteProduct = repository.DeleteProduct(productId);

            //ako je Produkt uspeno obrisan
            if (deleteProduct != null)
            {
                //upisujemo u Dictionary poruku da je Produkt uspesno obrisan iz baze
                TempData["message"] = string.Format("{0} Has been deleted", deleteProduct.Name);
            }

            //vracamo ka browseru view koji ce da sadrzi azuriran spisak Produkt-a iz baze
            return RedirectToAction("Index");
        }
    }
}