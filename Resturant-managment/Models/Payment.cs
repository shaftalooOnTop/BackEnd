using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
    public enum paymentType
    {
        prePaid,
        onlinePaid,
        inPlacePaid
    }
	public class Payment:BaseClass
	{
        public paymentType PaymentType { get; set; }
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("IdentityId")]
        public virtual RestaurantIdentity Identity { get; set; }
        public string IdentityId { get; set; }


    }
}

