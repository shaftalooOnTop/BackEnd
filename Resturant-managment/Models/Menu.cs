﻿using Resturant_managment.Models.Base;
using System.Text.Json.Serialization;
namespace Resturant_managment.Models
{
	public class Menu:BaseClass
	{
		public string Name { get; set; }
		public virtual List<Category>? Categories { get; set; }
	
		public int Restaurantid { get; set; }
		[JsonIgnore]
		public virtual Restaurant Restaurant { get; set; }
	}
}

