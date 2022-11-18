using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Category:BaseClass
	{
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
        public virtual List<Food>? Foods { get; set; }
        [JsonIgnore]
        [ForeignKey("RestaurantId")]
        public virtual Restaurant? Restaurant { get; set; }
      
    }
}

