using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveTableController : ControllerBase
    {
        private readonly RmDbContext _db;

        public  ReserveTable(RmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Post(ReserveTable r)
        {
            _db.Orders.Add(r);
            _db.SaveChangesAsync();
            return Ok(r.trCode);
        }

        [HttpGet("{id}")]
        public ActionResult<ReserveTable> Get(int id)
        {
            var result = _db.ReserveTable.Find(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var o = _db.ReserveTable.Find(id);
            if (o == null) return NotFound();
            _db.Remove(o);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(ReserveTable r)
        {
            if (r.id == 0) return NotFound();
            _db.Update(r);
            _db.SaveChangesAsync();
            return Ok(r.trCode);
        }



    }

}
