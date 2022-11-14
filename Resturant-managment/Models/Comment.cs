using System.ComponentModel.DataAnnotations.Schema;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Comment:BaseClass
{
    public string Value { get; set; }
    public int Rate { get; set; } 
    public virtual RestaurantIdentity RestaurantUser { get; set; }
    public virtual Restaurant Restaurant { get; set; }
    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }
}