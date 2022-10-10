using System;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Food:BaseClass
	{
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
    }
}

