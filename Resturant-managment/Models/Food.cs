 using System;
using System.ComponentModel.DataAnnotations.Schema;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Food:BaseClass
	{
		public string? Name { get; set; }
        public int ? Price { get; set; }
        public string? Image { get; set; }
        public int? Categoryid { get; set; }
        public int Count { get; set; }
        // public int? Orderid { get; set; }
        public string FoodDescription { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Order> ordered { get; set; }
	}
}

