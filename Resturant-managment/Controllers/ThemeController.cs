using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly RmDbContext _db;
        public ThemeController(RmDbContext db)
        {
            _db = db;
        }

        [HttpGet("ByRestauntId")]
        public ActionResult<List<ThemeOfTable>> get(int restaurantid)
        {
            var p = _db.ThemeOfTables.Where(x => x.restaurantid == restaurantid).ToList();
            return Ok(p);
        }

        [HttpGet("id")]
        public ThemeOfTable? Get(int id)
        {
            return _db.ThemeOfTables.Find(id);
        }

        [HttpPost]
        public ActionResult Post(ThemeOfTable value)
        {
            _db.Add(value);
            _db.SaveChanges();
            return Ok(value);
        }

        [HttpPut]
        public ActionResult Put(ThemeOfTable value)
        {
            if (value.id == 0) return NotFound();
            _db.Update(value);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<ThemeOfTable> Delete(int id)
        {
            var p = _db.ThemeOfTables.Find(id);
            if (p == null) return NotFound();
            _db.Remove(p);
            _db.SaveChanges();
            return Ok(p);
        }


    }
}
