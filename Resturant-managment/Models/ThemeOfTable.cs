using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class ThemeOfTable :BaseClass
    {
        public string theme { get; set; }
        [ForeignKey("restaurantid")]
        public int? restaurantid { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
