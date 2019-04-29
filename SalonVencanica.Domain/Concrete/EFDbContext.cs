using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Concrete
{
    //ovo je klasa za kontekst baze koji sadrzi tabele baze Produkt i Korisnici
    //connection string mora da ima isti naziv kao ova klasa
    //koriscena je u klasama: 'EFProductRepository', 'FormsAuthenticationProvider', 'Configuration' 
    public class EFDbContext : DbContext
    {
        //tabela Products iz baze
        //setuje se i pristupa mu se u klasi 'EFProductRepository'
        public DbSet<Product> Products { get; set; }

        //tabela Users iz baze
        //setuje se i pristupa mu se u klasi FormsAuthenticationProvider
        public DbSet<User> Users { get; set; }
    }
}
