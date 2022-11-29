﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public RestaurantTable? Get(int id)
        {
            return _db.RestaurantTables.Find(id);
        }
        [HttpGet("{restaurantid}")]
        public List<RestaurantTable> Gett(int restaurantid)
        {
            return _db.RestaurantTables.Where(x => x.RestaurantId == restaurantid).ToList();
        }

        [HttpPost]
        public ActionResult Post(RestaurantTable t)

        {
            _db.Add(t);
            _db.SaveChanges();
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t = _db.RestaurantTables.Find(id);
            if (t == null) return NotFound();
            _db.Remove(t);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(RestaurantTable t)
        {
            if (t.id == 0) return NotFound();
            _db.Update(t);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet(" ")]
        public async Task<string> Tablereserve(int tableid)
        {
            var t = _db.RestaurantTables.Find(tableid);
            var result = _db.ReserveTables.Where(x => x.TableId == t.id)
               .Where(x =>

               (x.ReserveTime.ReserveTime.AddHours(x.ExpireHours) >= DateTime.Now))
          ;
            if (result == null)
            {
                return "this table is not reserved";

            }
            else
            {
                return "this table is reserved";
            }
        }
    }
}
