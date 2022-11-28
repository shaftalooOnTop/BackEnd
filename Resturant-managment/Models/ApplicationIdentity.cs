using Microsoft.AspNetCore.Identity;

namespace Resturant_managment.Models;

public class RestaurantIdentity:IdentityUser
{
    public string FullName { get; set; }


        public string Picture { get; set; }

        public virtual City? city { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public virtual List<Payment> Payments { get; set; }
}