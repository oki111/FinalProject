using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Entities
{
    //ova klasa predtsvlja sadrzaj korpe sa Linijama Korpe odnosno Produktima koje je korisnik odabrao
    //koristi se u sledecim klasama: IOrderProcessor, EmailOrderProcessor, CartModelBinder, CartIndexBiewModel, CartController, Global.asax.cs
    public class Cart
    {
        //privatna lista sa objektima koji predstavljaju Liniju Korpe
        //koristi se samo u ovoj klasi
        List<CartLine> lineCollection = new List<CartLine>();

        //ova funkcija dodaje Liniju u Korpu na osnovu Produkta i njegove kolicine
        //poziva se u klasi CartController
        public void AddItem(Product product, int quantity)
        {
            //prvo proveravamo da li ova linija vec postoji u korpi na osnovu zeljenog Id-a
            CartLine line = lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            //ako ne postoji, onda je dodajemo kao novu liniju
            if(line == null)
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity});

            //ako postoji, onda samo uvecamo kolicinu ove linije za jedan
            else
                line.Quantity += quantity;
        }

        //ova funkcija uklanja odredjenu liniju iz korpe
        //poziva se u klasi CartController
        public void RemoveLine(Product product)
        {
            //pronadjemo liniju koja odgovara zeljenom Produkt Id-u i jednostavno ga uklonimo
            lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        //ova funkcija racuna ukupnu vrednost svih linija u korpi
        //poziva se u klasi EmailOrderProcessor
        public decimal ComputeTotalValue()
        {
            //sabiramo sve elemente Liste sa Linijama korpe tako sto mnozimo cenu Produkta te linije sa kolicinom Produkta svake linije
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        //ova postavka vraca sve linije Korpe ka kontrolerima gde je potrebna
        //pristupa mu se u klasi EmailOrderProcessor, CartCOntroller
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        //ova funkcija jednostavno brise sve linije Korpe
        //poziva se u klasi CartController
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
