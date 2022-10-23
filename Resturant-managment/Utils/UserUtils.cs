using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;


namespace Resturant_managment.Utils;

public class UserUtils:ControllerBase
{
    public UserModel GetCurrentUser()
    {
        
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new UserModel
            {
                Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
            };
        }
        return null;
    }
}