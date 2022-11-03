using Microsoft.AspNetCore.Identity;

namespace Resturant_managment.Models;

public class RestaurantIdentity:IdentityUser
{
    public string FullName { get; set; }
}