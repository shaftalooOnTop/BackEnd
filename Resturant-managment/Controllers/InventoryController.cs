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
        [HttpGet("Get/{id}")]
        public Inventory Get(int id)
        {
            return _db.Inventories.Find(id);
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
        public ActionResult Delete(int id)
        {
            var x = _db.
                Inventories.Find(id);
            _db.Remove(x);
            return Ok(x);
        }
    }
}
