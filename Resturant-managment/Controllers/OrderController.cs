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
    public class OrderController : ControllerBase
    {
        private readonly RmDbContext _db;
        private readonly UserManager<RestaurantIdentity> _userManager;
        public OrderController(RmDbContext db , UserManager<RestaurantIdentity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Ok(order);
        }


        [HttpGet("id")]
        public ActionResult<Order> Get(int id)
        {
            var result = _db.Orders.Find(id);
            return Ok(result);
        }

        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            var o = _db.Orders.Find(id);
            if (o == null) return NotFound();
            _db.Remove(o);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Order o)
        {
            if (o.id == 0) return NotFound();
            _db.Update(o);
            _db.SaveChanges();
            return Ok(o);
        }

        [Authorize]
        [HttpGet("GetUserActiveOrder")]
        public async  Task<List<Order>> GetOrder()
        {

            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var result = _db.Orders.Where(x => x.RestaurantIdentityId == user.Id)
               ;
            return result.ToList();
        }

        [HttpGet("RestaurantOrders")]
        public  List<Order> RestaurantOrders(string RestaurantId)
        {
            var result = _db.Orders.Where(x => x.RestaurantIdentityId == RestaurantId);
                

            return result.ToList();
        }

        [HttpPut("changeByStatus")]
        public  ActionResult<List<Order>> ChangeOrder(Orderstatus status , int orderid)
        {
            var o = _db.Orders.Find(orderid);
            o.stat = status;
            _db.Update(o);
            _db.SaveChanges();
            return Ok(o);

        }

        [HttpPut("ChangeOrderByOrderId")]
        public  ActionResult ChangeOrderByOrderId(int orderid)
        { 
            var o = _db.Orders.Find(orderid);
            _db.Update(o);
            _db.SaveChanges();
            return Ok(o);

        }
        

    }

}
