using Microsoft.Build.Framework;

namespace Resturant_managment.Models;

public class UserLogin
{
    public string Id { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
}