using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class ReserveTable : BaseClass
    {
       public virtual Payment Payment { get; set; }
        
        
        public int ExpireHours { get; set; } = 2;
        [ForeignKey("RestaurantIdentityId")]
        public virtual RestaurantIdentity RestaurantIdentity { get; set; }
        public virtual string RestaurantIdentityId { get; set; }

        [ForeignKey("TableId")]
        public virtual RestaurantTable Table { get; set; }
        public virtual int TableId { get; set; }

        [ForeignKey("ReserveTimeId")]
        public virtual resrvetime ReserveTime { get; set; }
        public virtual int ReserveTimeId { get; set; }





    }
}
