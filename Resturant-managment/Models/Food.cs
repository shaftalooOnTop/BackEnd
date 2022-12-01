﻿ using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Category? Category { get; set; }
        public virtual ICollection<Order>? orders { get; set; }
        public virtual List<FoodOrder>? FoodOrders { get; set; }
        [NotMapped]
        public int FoodCnt { get; set; } = 0;
    }
}

