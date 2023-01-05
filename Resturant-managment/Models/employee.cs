using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public enum jobtype
    {
        fulltime, parttime
    }
    public class Employee : BaseClass
    {
        public int earning { get; set; }
        public DateTime start { get; set; }
        public jobtype? jobtype { get; set; }
        public string position { get; set; }
        public virtual List<EntranceMangment>? entranceMangments { get; set; }
        public int restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant? Restaurant { get; set; }


        public string? identityid { get; set; }
        [ForeignKey("identityid")]
        public virtual RestaurantIdentity? RestaurantIdentity { get; set; }
    }
}
