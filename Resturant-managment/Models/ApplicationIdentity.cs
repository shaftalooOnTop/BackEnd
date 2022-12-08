using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Resturant_managment.Models;

public class RestaurantIdentity:IdentityUser
{
    public string FullName { get; set; }


        public string Picture { get; set; }
        public virtual int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City? city { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
        
        public virtual List<Payment> Payments { get; set; }

        public virtual List<ReserveTable> restable { get; set; }
        
}