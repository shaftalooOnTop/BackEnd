
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{
	public class City:BaseClass
	{
        public string CityName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Restaurant>? Restaurants { get; set; }
        [ForeignKey("IdentityId")]
        [JsonIgnore]
        public virtual List<RestaurantIdentity>? Identity { get; set; }
        [JsonIgnore]
        public virtual int IdentityId { get; set; }
    }
}

