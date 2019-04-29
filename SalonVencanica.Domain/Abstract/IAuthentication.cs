using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Abstract
{
    //ovaj interfejs sadrzi abstraktnu definiciju Autentikacije za korisnika
    //implementiran od strane klase 'FormsAuthenticationProvider'
    //upotrebljen u kontroleru 'AccountController'
    public interface IAuthentication
    {
        //definicija funkcije, implelentirana u klasi 'FormsAuthenticationProvider'
        bool Authenticate(string username, string password);

        //definicija funkcije, implelentirana u klasi 'FormsAuthenticationProvider'
        bool Logout();
    }
}
