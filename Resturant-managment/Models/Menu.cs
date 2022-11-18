using System;
using Resturant_managment.Models.Base;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Resturant_managment.Models
{
	public class Menu:BaseClass
	{
		public string Name { get; set; }
		public virtual List<Category>? Categories { get; set; }
		[JsonIgnore]
		public int Restaurantid { get; set; }
		[JsonIgnore]
		public virtual Restaurant Restaurant { get; set; }
	}
}

