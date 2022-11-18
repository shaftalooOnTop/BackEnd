using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Resturant_managment.Models.Base;
namespace Resturant_managment.Models
{
	public class Category:BaseClass
	{
        public string CategoryName { get; set; }
        public int MenuId { get; set; }

        public  virtual List<Food>? Foods { get; set; }
        [JsonIgnore]
        [ForeignKey("MenuId")]
        public virtual Menu? Menu { get; set; }
      
    }
}

