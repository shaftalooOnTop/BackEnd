using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
	public class Tag:BaseClass
	{        
		public int  RestaurantId { get; set; }
		[ForeignKey("RestaurantId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
		public virtual Restaurant? Restaurant { get; set; }
        public string value { get; set; }

    }
}

