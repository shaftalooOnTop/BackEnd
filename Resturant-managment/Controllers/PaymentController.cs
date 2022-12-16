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
    public class PaymentController : ControllerBase
    {
        // GET: api/Payment
        private readonly RmDbContext _db;
        private readonly UserManager<RestaurantIdentity> _userManager;
        private RestaurantIdentity _RestaurantUser;

        private RestaurantIdentity RestaurantUser

        {
            get
            {
                if (_RestaurantUser == null) return GetUser();
                else return _RestaurantUser;
            }
        }
        private RestaurantIdentity GetUser()
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return _userManager.FindByEmailAsync(email).Result;
        }
        public PaymentController(RmDbContext db, UserManager<RestaurantIdentity> userManager)
        {
            _db = db;
            _userManager = userManager;

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Payment> Get()
        {
            return _db.Payments.ToList();
        }

        // GET: api/Payment/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Payment> Get(int id)
        {
            var x = _db.Payments.Find(id);
            if (x == null) return NotFound("PaymentNotfound");
            return x;
        }

        // POST: api/Payment
        [HttpPost]
        [Authorize]
        public ActionResult<Payment> Post([FromBody] Payment value)
        {
           
            if(!ModelState.IsValid)return BadRequest();
            value.Identity = RestaurantUser;
            value.IdentityId = RestaurantUser.Id;
            _db.Payments.Add(value);
            _db.SaveChanges();
            var s = _db.Orders.Find(value.OrderId);
            if (s == null) return BadRequest();
            s.stat = Orderstatus.paid;
            _db.Update(s);
            _db.SaveChanges();
            return Ok(value);
        }

        // PUT: api/Payment/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/Payment/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
