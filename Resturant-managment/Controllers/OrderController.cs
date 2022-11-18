using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RmDbContext _db;

        public OrderController(RmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var result = _db.Orders.Find(id);
            return Ok(result);
        }
        

}
}