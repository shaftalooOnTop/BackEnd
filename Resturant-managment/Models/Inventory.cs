using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
	public class Inventory:BaseClass
	{
        public string Name { get; set; }
        public int Count { get; set; }
        public int RestaurantId { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }

    }
}

