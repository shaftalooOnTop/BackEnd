using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models;

public class Order:BaseClass
{
    public virtual List<Food> Foods { get; set; }
    public int Restaurantid { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("RestaurantId")]
    public virtual Restaurant? Restaurant { get; set; }


    public int UserId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("UserId")]
    public virtual UserModel? UserModel { get; set; }
}