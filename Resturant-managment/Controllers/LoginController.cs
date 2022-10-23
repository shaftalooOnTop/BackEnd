using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _conf;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(IConfiguration conf,UserManager<IdentityUser> userManager)
        {
            _conf = conf;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = "";
            if (user != null)
            {
                var token = "";
                return Ok(user);
            }

            return NotFound(user);
        }

        public string Generate(UserModel User)
        {
            return "";
        }

        public UserModel Authenticate(UserLogin login)
        {
            return null;
        }
    }
}
