using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
    public enum paymentType
    {
        Wallet,
        Online,
        InPlace
    }
    public enum paymentState
    {
        Succeed,
        Failed
    }
	public class Payment:BaseClass
	{
        public paymentType PaymentType { get; set; }
        public paymentState PaymentState { get; set; }
        [ForeignKey("OrderId")]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Order? Order { get; set; }
        public int? OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("IdentityId")]
        [IgnoreDataMember]
        public virtual RestaurantIdentity? Identity { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public string ? IdentityId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ReserveTable ?ReserveTable { get; set; }
        

    }
}

