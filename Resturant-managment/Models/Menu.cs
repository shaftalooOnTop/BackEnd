using System;
using Resturant_managment.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
	public class Menu:BaseClass
	{
		public string Name { get; set; }
		public virtual List<Category>? Categories { get; set; }
		public int Restaurantid { get; set; }
		// public virtual Restaurant Restaurant { get; set; }
	}
}

