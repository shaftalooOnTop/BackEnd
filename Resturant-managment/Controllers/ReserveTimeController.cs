using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveTimeController : ControllerBase
    {
        private readonly RmDbContext _db;

        public ReserveTimeController(RmDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<resrvetime> Get()
        {
            return _db.Resrvetimes.ToList();
        }

        [HttpGet("id")]
        public resrvetime Get(int id)
        {
            return _db.Resrvetimes.Find(id);
        }

        [HttpDelete("id")]
        public ActionResult<resrvetime> Delete(int id)
        {
            var rt = _db.Resrvetimes.Find(id);
            if (rt == null) return NotFound();
            _db.Remove(rt);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(resrvetime rt)
        {
            _db.Resrvetimes.Add(rt);
            _db.SaveChanges();
            return Ok(rt);
        }


        [HttpPut]
        public ActionResult<resrvetime> Put(resrvetime rt)
        {
            if (rt.id == 0) return NotFound();

            _db.Resrvetimes.Update(rt);
            _db.SaveChangesAsync();
            return Ok(rt);
        }

    }
}
