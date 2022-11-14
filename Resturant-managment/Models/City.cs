using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
	public class City:BaseClass
	{
        public string CityName { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        [ForeignKey("IdentityId")]
        public virtual List<RestaurantIdentity>? Identity { get; set; }
        public virtual int IdentityId { get; set; }
    }
}

