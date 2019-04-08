using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonVencanica.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a valid city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a valid state name")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a valid country name")]
        public string Country { get; set; }

        public string Zip { get; set; }

        public bool GiftWrap { get; set; }
    }
}
