using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Comment:BaseClass
{
    public string Value { get; set; }
    public int Rate { get; set; } 
    public virtual RestaurantIdentity RestaurantUser { get; set; }
    [JsonIgnore]
    public virtual Restaurant Restaurant { get; set; }
    [JsonIgnore]
    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }
}