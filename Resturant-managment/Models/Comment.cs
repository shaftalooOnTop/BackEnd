using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Comment:BaseClass
{
    public string Value { get; set; }
    public int Rate { get; set; } 
    public RestaurantIdentity RestaurantUser { get; set; }
}