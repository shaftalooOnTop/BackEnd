using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Category:BaseClass
	{
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
        public virtual List<Food>? Foods { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("RestaurantId")]
        [IgnoreDataMember]
        public virtual Restaurant? Restaurant { get; set; }
      
    }
}

