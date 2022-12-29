using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public ActionResult Post(Order order)
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var user =  _userManager.FindByEmailAsync(email).Result;
            order.RestaurantIdentity = user;
            order.RestaurantIdentityId = user.Id;
            if (order.Foods!=null){
                var foods = order.Foods;
                order.Foods = new List<Food>();
                foreach (var i in foods)
                {
                    var f = _db.Foods.Find(i.id);
                    if (f.Count <= 0) return NotFound("Food not available");
                    _db.Attach(f);
                }
                foreach (var i in foods)
                    order.Foods.AddRange(_db.Foods.Local.Where(x => x.id == i.id));
            }
            if(order.Payment == null && order.stat == Orderstatus.finished) {
                return BadRequest("order cant be finished if it hasnt been paid ");
            }
            if(order.Payment != null)
            {
                order.stat = Orderstatus.finished;
            }
     
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Ok(order);
        }

        [HttpGet("Receipt")]
        public ActionResult<Order> receipt(int orderid)
        {
            var order = _db.Orders.FirstOrDefault(x => x.id == orderid);
            if (order.stat != Orderstatus.finished)
            {
                return BadRequest("this order isnt paid yet");
            }
            return Ok(order);
        }
        [HttpGet("orderstatus")]
        public ActionResult<Order> orderstatus( Orderstatus statu)
        {
            var o =_db.Orders.Where(x => x.stat==statu);
            return Ok(o);
        }

        [HttpGet("id")]
        public ActionResult<Order> Get(int id)
        {
            var result = _db.Orders.FirstOrDefault(x=>x.id==id);
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
            if (o.Payment == null && o.stat == Orderstatus.finished)
            {
                return BadRequest("order cant be finished if it hasnt been paid ");
            }
            if (o.Payment != null)
            {
                o.stat = Orderstatus.finished;
            }
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
            var result = _db.Orders.Where(x => x.RestaurantIdentityId == user.Id).Where(x=>x.stat!=Orderstatus.finished);
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
            if (o.Payment == null && status == Orderstatus.finished)
            {
                return BadRequest("order cant be finished if it hasnt been paid ");
            }
            if (o.Payment != null)
            {
                o.stat = Orderstatus.finished;
            }
            _db.Update(o);
            _db.SaveChanges();
            return Ok(o);

        }

        [HttpPut("ChangeOrdertoFinishedByOrderId")]
        public  ActionResult ChangeOrdertoFinishedByOrderId(int orderid)
        { 
            var o = _db.Orders.Find(orderid);
            if (o.Payment== null && o.stat == Orderstatus.finished)
            {
                return BadRequest("order cant be finished if it hasnt been paid ");
            }
            if (o.Payment != null)
            {
                o.stat = Orderstatus.finished;
            }
            _db.Update(o);
            _db.SaveChanges();
            return Ok(o);

        }

        [HttpGet("TotalNumberOfOrders")]
        public ActionResult<List<Order>> TotalNumberOfOrders(int restaurantid)
        {
            return Ok( _db.Orders.Where(x=>x.restaurantId == restaurantid).ToList().Count());
        }



    }

}
