using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Comment:BaseClass
{
    public string Value { get; set; }
    public int Rate { get; set; }
    [JsonIgnore]
    public virtual RestaurantIdentity? RestaurantUser { get; set; }
    [JsonIgnore]
    [ForeignKey("RestaurantId")]
    public virtual Restaurant? Restaurant { get; set; }
    
    public int RestaurantId { get; set; }
}