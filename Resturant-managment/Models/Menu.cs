using System;
using Resturant_managment.Models.Base;
using System.Collections.Generic;
namespace Resturant_managment.Models
{
	public class Menu:BaseClass
	{
		string Name { get; set; }
		List<Category> Categories { get; set; }
	}
}

