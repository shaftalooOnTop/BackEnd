using System;
namespace Resturant_managment.Models.Base
{
	public class BaseClass
	{
        public int id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

