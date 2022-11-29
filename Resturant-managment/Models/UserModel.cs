using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models;

public class UserModel : BaseClass
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string Role { get; set; }

    public  virtual List<ReserveTable> restable { get; set; }

    

}