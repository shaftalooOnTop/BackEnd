using System;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
	public class Tag:BaseClass
	{
        public int  ResturantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string value { get; set; }

    }
}

