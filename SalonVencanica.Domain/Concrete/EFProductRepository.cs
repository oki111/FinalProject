using SalonVencanica.Domain.Abstract;
using SalonVencanica.Domain.Entities;
using System.Collections.Generic;

namespace SalonVencanica.Domain.Concrete
{
    //ova klasa je konkretna implementacija Produkt-repozitori klase za tabelu baze Produkt. Vrsi CRUD operacije za ovu tabelu
    //upotrebljena je preko svog interfejsa u kontrolerima 'ProductController' 'CartController' 'AdminController' 'NavController'
    public class EFProductRepository : IProductRepository
    {
        //kontekst koji vrsi upit u bazu, mora biti isti kao i connection string
        //setuje se i pristupa mu se samo u ovoj klasi
        readonly EFDbContext context = new EFDbContext();

        //numericka lista koja salje tabelu Products od baze ka kontrolerima: CartController, AdminController, ProductController, NavController
        //dakle setuje se u bazi
        public IEnumerable<Product> Products { get { return context.Products; } }
        
        //ova funkcija vrsi upis Produkt objekata u bazu
        //poziva se u klasama: EFProductRepository i AdminController
        public void SaveProduct(Product product)
        {
            //ako je indeks produkta 0 to znaci da je to prvi produkt objekat koji se dodaje u bazu i da je baza do prethodno bila prazna
            if (product.ProductId == 0) 
                context.Products.Add(product); 
            
            //u suprotnom, baza nije prazna 
            else
            {
                //pa moramo u njoj pronaci vec postojeci produkt objekat na osnovu zadatog ProductId
                Product dbEntry = context.Products.Find(product.ProductId);

                //ako smo uspesno pronasli produkt objekat
                if (dbEntry != null)
                {
                    //onda njegove postojece vrednosti preinacujemo u vrednosti produkta koje se upisuju
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;

                    dbEntry.ImagePath = product.ImagePath;
                    
                }


            }

            //na kraju, vrsimo konacan upis promena u aktuelnu bazu
            context.SaveChanges();
        }

        
        //ova funkcija brise Produkt objekte iz baze na osnovu zadatog ProductId
        //poziva se u klasama: EFProductRepository i AdminController
        public Product DeleteProduct(int productId)
        {
            //prvo pronalazimo Produkt objekat u bazi koji zelimo da obrisemo
            Product dbEntry = context.Products.Find(productId); 

            //ako Produkt objekat postoji u bazi
            if (dbEntry != null) 
            {
                //brisemo ga iz baze i cuvamo promene u bazi
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }

            //vracamo upravo obrisani Produkt objekat ka kontroleru
            return dbEntry;
        }
    }
}
