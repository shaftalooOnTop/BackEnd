
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{
	public class City:BaseClass
	{
        public string CityName { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Restaurant>? Restaurants { get; set; }
        
    }
}

