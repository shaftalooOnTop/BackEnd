using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Resturant_managment.Models
{
    public class ThemeOfTable :BaseClass
    {
        public string theme { get; set; }


        public int? restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant? Restaurant { get; set; }
    }
}
