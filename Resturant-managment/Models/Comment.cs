using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Comment:BaseClass
{
    public string Value { get; set; }
    public int Rate { get; set; }
    [JsonIgnore]
    [IgnoreDataMember]
    public virtual RestaurantIdentity? RestaurantUser { get; set; }
    [JsonIgnore]
    [ForeignKey("RestaurantId")]
    [IgnoreDataMember]

    public virtual Restaurant? Restaurant { get; set; }
    
    public int RestaurantId { get; set; }
    public string ManagerComment { get; set; }
}