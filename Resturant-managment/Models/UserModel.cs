using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class UserModel : BaseClass
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string Role { get; set; }
}