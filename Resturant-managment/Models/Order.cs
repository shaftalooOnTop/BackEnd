using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models;

public class Order:BaseClass
{
    public enum status
    {
        finished, inProcess , accepted
    }

    public virtual ICollection<Food> Foods { get; set; }
    public virtual List<FoodOrder> FoodOrders { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("RestaurantIdentityId")]
    public virtual RestaurantIdentity RestaurantIdentity { get; set; }
    public virtual string RestaurantIdentityId { get; set; }

    public virtual Payment Payment { get; set; }

    public int UserId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("UserId")]
    public virtual UserModel? UserModel { get; set; }
    public virtual int RestaurantId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("RestaurantId")]
    public virtual Restaurant Restaurant { get; set; }

}