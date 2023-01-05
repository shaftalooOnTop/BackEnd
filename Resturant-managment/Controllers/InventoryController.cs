using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly RmDbContext _db;

        public InventoryController(RmDbContext db)
        {
            _db = db;
        }
        // GET: api/Inventory
        [Authorize(Roles ="Admin")]
        [HttpGet]

        public List<Inventory> Get()
        {
            return _db.Inventories.ToList();
        }

        // GET: api/Inventory/5
        [HttpGet("Get/{Restaurantid}")]
        public List<Inventory> Get(int Restaurantid)
        {
            return _db.Inventories.Where(x=>x.RestaurantId==Restaurantid).ToList();
        }

        // POST: api/Inventory
        [HttpPost]
        public ActionResult Post([FromBody] Inventory value)
        {
            _db.Add(value);
            _db.SaveChanges();
            return Created("", value);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Inventory value)

        {
            _db.Update(value);
            _db.SaveChanges();
            return Ok(value);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public ActionResult<Inventory> Delete(int id)
        {
            var x = _db.
                Inventories.Find(id);
            if (x == null) return NotFound();
            _db.Remove(x);
            _db.SaveChanges();
            return Ok(x);
        }
    }
}
