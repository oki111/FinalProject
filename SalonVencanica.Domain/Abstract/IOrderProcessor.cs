using SalonVencanica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Abstract
{
    //ovaj interfejs sadrzi abstraktnu definiciju Procesora Narudzbenice
    //implementiran od strane klase 'EmailOrderProcessor'
    //upotrebljen u kontroleru 'CartController'
    public interface IOrderProcessor
    {
        //definicija funkcije, implelentirana u klasi 'EmailOrderProcessor'
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
