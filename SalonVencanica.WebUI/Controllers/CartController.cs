using SalonVencanica.Domain.Abstract;
using SalonVencanica.Domain.Entities;
using SalonVencanica.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Controllers
{
    //klasa kontrolera koji se koristi od strane View-a koji pripadju ovom kontroleru
    public class CartController : Controller
    {
        //privatne globalne varijable koje sadrze repozitori odnosno bazu
        IProductRepository repository;
        IOrderProcessor orderProcessor;

        //konstruktor sa injekcijom repozitorija odnosno baze
        public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde ce biti prikazan sadrzaj korpe
        public ViewResult Index(Cart cart, string returnUrl)
        {
            //vracamo ka browseru view koji ce da sadrzi sadrzaj korpe i setujemo postavke modela koji sadrzi objekat korpe i adresu
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        //ova 'http-get' funkcija vraca parcijalni View koji prikazuje zbir korpe i nalazi se u gornjem desnom uglu
        public PartialViewResult Summary(Cart cart)
        {
            //vracamo ka browseru parcijalni view koji prikazuje zbir korpe
            return PartialView(cart);
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde ce biti prikazana forma za popunjavanje podataka narudzbenice
        public ViewResult Checkout()
        {
            //vracamo ka browseru view koji sadrzi formu za popunjavanje podataka narudzbenice
            return View(new ShippingDetails());
        }


        //ova 'http-post' funkcija redirektuje korisnika na View gde ce biti prikazana poruka o uspesnoj porudzbini ili ce obavestiti da je korpa prazna ukoliko nema bar jedne stavke u njoj
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            //ako je korpa prazna
            if (cart.Lines.Count() == 0)
            {
                //upisujemo u dictionary poruku da je korpa prazna
                ModelState.AddModelError("", "Izvinite, vasa korpa je prazna!");
            }

            //ako je stanje modela validno
            if (ModelState.IsValid)
            {
                //pozivamo funkciju koja procesuira porudzbinu
                orderProcessor.ProcessOrder(cart, shippingDetails);

                //brisemo sadrzaj korpe
                cart.Clear();

                //vracamo ka browseru view gde pise da je porudzbina uspesno prihvacena
                return View("Completed");
            }

            //ako stanje modela nije validno
            else
            {
                //vracamo ka browseru view gde pisu detalji porudzbine, odnosno ostajemo na ovom view-u
                return View(shippingDetails);
            }
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde ce biti prikazan sadrzaj korpe nakon dodavanja novog artikla u korpu
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            //prvo pronalazimo zeljeni produkt koji dodajemo u korpu preko ProduktId u bazi
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            //ako je Produkt pronadjen u bazi
            if (product != null)
            {
                //dodajemo ga u korpu
                cart.AddItem(product, 1);
            }

            //vracamo ka browseru view na kome je prikazan sadrzaj korpe
            return RedirectToAction("Index", new { returnUrl });
        }

        //ova 'http-get' funkcija redirektuje korisnika na View gde ce biti prikazan sadrzaj korpe nakon brisanja odredjenog artikla iz korpe
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            //prvo pronalazimo zeljeni produkt koji brisemo iz korpe preko ProduktId u bazi
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            //ako je Produkt pronadjen u bazi
            if (product != null)
            {
                //brisemo ga iz korpe
                cart.RemoveLine(product);
            }

            //vracamo ka browseru view na kome je prikazan sadrzaj korpe
            return RedirectToAction("Index", new { returnUrl });
        }

         
    }
}