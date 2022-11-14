using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
	public class City:BaseClass
	{
        public string CityName { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}

