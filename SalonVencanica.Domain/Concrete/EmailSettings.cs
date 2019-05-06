using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Concrete
{
    //ova klasa sadrzi unapred zadate postavke za slanje email-a putem smtp servisa
    //koristi se u klasi 'EmailOrderProcessor'
    public class EmailSettings
    {
        public string MailFromAddress = "ialeksan007@gmail.com";
        public bool UseSsl = true;
        public string Username = "ialeksan007@gmail.com";
        public string Password = "teupvncuhinfdlgk"; //google app password
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
