﻿using System;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Food:BaseClass
	{
		public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
        public int Categoryid { get; set; }
        public int Count { get; set; }
        // public int? Orderid { get; set; }
        // public virtual Category Category { get; set; }
	}
}

