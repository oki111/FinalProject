using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalonVencanica.Domain.Entities
{
    //ova klasa sadrzi postavke koje su identicne kolonama tabele baze Produkt
    //korsiti se u klasama CartLine, EFDbContext, IProductRepository, EFProductRepository, Cart, ProductListViewModel, AdminController, CartController
    public class Product
    {
        //svaka postavka je 'dekorisana' sa atributima Data Anotacije sto za krajnji rezultat ima da korisnik mora da popuni ove podatke u odredjenom formatu
        //ovi atributi se aktiviraju kada se aplikacija pokrene

        //setuje se u bazi a pristupa mu se u klasama EFProductRepository, Cart, ProductController, AdminController, CartController
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        //pristupa mu se u klasama EFProductRepository, EmailOrderProcessor, AdminController a setuje se samo u EFProductRepository
        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }

        //setuje se i pristupa mu se u klasi EFProductRepository
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        //korsiti se u klasama EFProductRepository, Cart, EmailOrderProcessor, a setuje se samo u EFProductRepository
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price.")]
        public decimal Price { get; set; }

        //korsiti se u klasama EFProductRepository, ProductController, NavController, a setuje se samo u EFProductRepository
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
    }
}
