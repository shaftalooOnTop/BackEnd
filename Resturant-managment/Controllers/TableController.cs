using Castle.Core.Internal;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TableController : ControllerBase
    {
        private readonly RmDbContext _db;

        public TableController(RmDbContext db)
        {
            _db = db;
        }
        [HttpGet("id")]

        public RestaurantTable? Get(int id)
        {
            return _db.RestaurantTables.Find(id);
        }
        [HttpGet("by restaurant")]
        public List<RestaurantTable> Gett(int restaurantid)
        {
            return _db.RestaurantTables.Where(x => x.RestaurantId == restaurantid).ToList();
        }

        [HttpPost]
        public ActionResult Post(RestaurantTable t)
        {
            var a = _db.RestaurantTables.Any(x => (x.RestaurantId == t.RestaurantId && x.number == t.number));
            if (!a)
            {
                _db.Add(t);
                _db.SaveChanges();
                return Ok(t);
            } 
            return new BadRequestResult();
            
        }

       


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t = _db.RestaurantTables.Find(id);
            if (t == null) return NotFound();
            _db.Remove(t);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(RestaurantTable t)
        {
            if (t.id == 0) return NotFound();
            _db.Update(t);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("tablerank")]
        public ActionResult<List<RestaurantTable>> rank(int restaurantid)
        {
            var r = _db.RestaurantTables.Where(x => x.RestaurantId == restaurantid).ToList();
            foreach (var i in r)
            {
                var c = _db.ReserveTables.Where(x => x.TableId == i.id).ToList().Count();
                i.rank = c;
            }

            var t = _db.RestaurantTables.Where(x => x.RestaurantId == restaurantid).OrderBy(x=>x.rank).Take(3).ToList();
            return Ok();
        }

    }
}
