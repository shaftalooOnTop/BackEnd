using System;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Category:BaseClass
	{
        public string? CategoryName { get; set; }
        List<Food> Foods { get; set; }
    }
}

