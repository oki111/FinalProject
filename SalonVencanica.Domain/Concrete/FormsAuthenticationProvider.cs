using SalonVencanica.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Concrete
{
    //ova klasa je konkretna implementacija abstraktne Autentikacije
    //upotrebljena je preko svog interfejsa u kontroleru 'AccountController'
    public class FormsAuthenticationProvider : IAuthentication
    {
        //kontekst koji vrsi upit u bazu, mora biti isti kao i connection string
        //privatna globalna varijabla, koristi se samo u ovoj klasi
        readonly EFDbContext context = new EFDbContext();

        //ova funkcija proverava da li u bazi postoji korisnik sa zadatim imenom i sifrom
        //poziva se u klasi 'AccountController'
        public bool Authenticate(string username, string password)
        {
            //prvo proveravamo u tabeli da li postoji korisnik sa zadatim imenom i sifrom
            var result = context.Users.FirstOrDefault(u => u.UserId == username && u.Password == password);

            //ako ne postoji vracamo ka kontroleru false
            if (result == null)
                return false;

            //ako postoji vracamo ka kontroleru true
            return true;
        }

        //ova funkcija jednostavno vraca true nakon uspesnog logout-a korisnika
        //trenutno se ne poziva ni u jednoj klasi
        public bool Logout()
        {
            return true;
        }
    }
}
