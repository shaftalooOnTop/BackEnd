using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models.Base
{
	public class BaseClass
	{
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Column(Order = 0)]
        public int id { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

