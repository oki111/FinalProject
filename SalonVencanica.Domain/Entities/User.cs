using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Entities
{
    //ova klasa sadrzi postavke koje su identicne kolonama tabele baze User
    //koristi se u klasi EFDbContext
    public class User
    {
        [Key] //atribut Data notacije koji ukazuje da je ovo Primary Key. Nije potrebno eksplicitno nazanaciti ga ovde, jer je ovo prva postavka, pa je po konvenciji automatki Primary Key
        //setuje se u bazi, pristupa mu se u klasi FormsAuthenticationProvider.cs
        public string UserId { get; set; }

        //setuje se u bazi, pristupa mu se u klasi FormsAuthenticationProvider.cs
        public string Password { get; set; }
    }
}
