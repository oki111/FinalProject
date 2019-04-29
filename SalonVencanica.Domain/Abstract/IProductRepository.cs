using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Abstract
{
    //ovaj interfejs sadrzi abstraktnu repozitorija za tableu baze Produkt
    //implementiran od strane klase 'EFroductRepository'
    //upotrebljen u kontrolerima 'ProductController' 'CartController' 'AdminController' 'NavController'
    public interface IProductRepository
    {
        //definicija funkcije, implelentirana u klasi 'EFroductRepository'
        IEnumerable<Product> Products { get; }

        //definicija funkcije, implelentirana u klasi 'EFroductRepository'
        void SaveProduct(Product product);

        //definicija funkcije, implelentirana u klasi 'EFroductRepository'
        Product DeleteProduct(int productId);
    }
}
