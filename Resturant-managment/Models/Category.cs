using System;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Category:BaseClass
	{
        public string? CategoryName { get; set; }
        // public int MenuId { get; set; }
        public List<Food>? Foods { get; set; }

        public virtual Menu? Menu { get; }
        public int? Menuid { get; set; }
    }
}

