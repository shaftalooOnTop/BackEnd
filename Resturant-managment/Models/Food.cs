 using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
 using System.Runtime.Serialization;
 using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Food:BaseClass
	{
		public string? Name { get; set; }
        public int ? Price { get; set; }
        [NotMapped]
        public string? Image { get; set; }
 
        [ForeignKey("PhotoId")]
        public virtual Photo? Photo { get; set; }
        public virtual int? PhotoId { get; set; }
        public int? Categoryid { get; set; }
        public int? Count { get; set; }
        public string? FoodDescription { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("Categoryid")]
        [IgnoreDataMember]
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual List<Order>? Orders { get; set; }
        [NotMapped]
        public int? FoodCnt { get; set; } = 0;
    }
}

