using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models;
public enum Orderstatus
{
    finished, inProcess, accepted
}
public class Order:BaseClass
{
   
   
    public Orderstatus stat { get; set; }
    public virtual ICollection<Food>? Foods { get; set; }
    public virtual List<FoodOrder>? FoodOrders { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("RestaurantIdentityId")]
    public virtual RestaurantIdentity? RestaurantIdentity { get; set; }
    public virtual string RestaurantIdentityId { get; set; }

    public virtual Payment? Payment { get; set; }

    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("restuarantId")]
    public virtual Restaurant? Restaurant { get; set; }
    public virtual int restaurantId { get; set; }
}