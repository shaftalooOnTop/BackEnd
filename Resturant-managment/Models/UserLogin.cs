using Microsoft.Build.Framework;

namespace Resturant_managment.Models;

public class UserLogin
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}