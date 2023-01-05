using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;
using Resturant_managment.Services;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeController : ControllerBase
    {
        private readonly UserManager<RestaurantIdentity> _userManager;
        private readonly JwtService _jwtService;
        private readonly RmDbContext _db;
        private readonly RestaurantIdentity _RestaurantUser = null;
        private readonly RoleManager<IdentityRole> _roleManager;

        private RestaurantIdentity RestaurantUser

        {
            get
            {
                if (_RestaurantUser == null) return GetUser();
                else return _RestaurantUser;
            }
        }
        public FakeController(RoleManager<IdentityRole> roleManager, UserManager<RestaurantIdentity> userManager, JwtService jwtService, RmDbContext db)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _db = db;
            _roleManager = roleManager;

        }
        private RestaurantIdentity GetUser()
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return _userManager.FindByEmailAsync(email).Result;
        }
        [HttpPost("Fakeuser")]
        public ActionResult FakeUser()
        {
            //var u = new UserController(_roleManager, _userManager, _jwtService, _db);
            //var users = new List<UserSignUp> {
            //    new UserSignUp
            //    {
            //         Age=21,
            //         city=
            //    },




            //};
            //u.PostUser();



            return Ok();
        }
        [HttpPost("FakeCity")]
        public ActionResult FakeCity()
        {
            var cities = new List<City>
            {
                new City
                {
                    CityName="Boushehr"
                },
                new City
                {
                    CityName="Zanjan"
                }
            };
            var c = new CityController(_db);
            foreach(var i in cities)
            {
                 c.Post(i);
            }
         return Ok();
        }

    }
}
