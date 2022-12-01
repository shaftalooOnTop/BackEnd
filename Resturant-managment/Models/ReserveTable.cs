using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{
    public class ReserveTable : BaseClass
    {
        public int? PaymentId { get; set; }
        [ForeignKey("PaymentId")]
       public virtual Payment ?Payment { get; set; }
        
        
        public int ExpireHours { get; set; } = 2;
        [ForeignKey("RestaurantIdentityId")]
        [IgnoreDataMember]
        public virtual RestaurantIdentity RestaurantIdentity { get; set; }
        public virtual string RestaurantIdentityId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("TableId")]
        [IgnoreDataMember]
        public virtual RestaurantTable Table { get; set; }
        public virtual int TableId { get; set; }

        [ForeignKey("ReserveTimeId")]
        public virtual resrvetime ReserveTime { get; set; }
        public virtual int ReserveTimeId { get; set; }





    }
}
