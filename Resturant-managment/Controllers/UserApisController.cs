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
    public class UserApisController : ControllerBase
    {
        private readonly UserManager<RestaurantIdentity> _userManager;
        private readonly RmDbContext _db;

        private RestaurantIdentity GetUser()
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return _userManager.FindByEmailAsync(email).Result;
        }
        public UserApisController(IConfiguration conf, UserManager<RestaurantIdentity> userManager, RmDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [Authorize]
        [HttpGet("GetOrdersHistory")]
        public ActionResult<List<Order>> GetOrdersHistory()
        {
            var user = GetUser();
            var result = _db.Orders.Where(u => u.RestaurantIdentityId == user.Id).OrderByDescending(x => x.DateCreated).ToList();
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetReservesHistory")]
        public ActionResult<List<Order>> GetReservesHistory()
        {
            var user = GetUser();
            var result = _db.ReserveTables.Where(u => u.RestaurantIdentityId == user.Id).OrderByDescending(x => x.DateCreated).ToList();
            return Ok(result);
        }
        [Authorize("Admin")]
        [HttpGet("RestaurantAdmin")]
        public ActionResult RestaurantAdmin()
        {
            var user = GetUser();
            //var res = _db.Restaurant.Where();
            return Ok();
        }
    }
}
