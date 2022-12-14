using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RmDbContext _db;

        public CategoriesController(RmDbContext db)
        {
            _db = db;
        }
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var t = _db.Categories.ToList();
            t.All(x => { x.Restaurant = null; return true; });
            return t;
        }

        [HttpGet("GetMenu")]
        public List<Category> GetMenu(int restaurantid)
        {
           return _db.Categories.Where(x => x.RestaurantId == restaurantid).ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public Category? Get(int id)
        {
            return _db.Categories.Find(id);
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult Post(Category value)

        {
            _db.Add(value);
            _db.SaveChanges();
            return Ok(value);
        }

        // PUT: api/Categories/5
        [HttpPut]
        public ActionResult Put(Category value)
        {
            if (value.id == 0) return NotFound();
            _db.Update(value);
            _db.SaveChanges();
            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t=_db.Categories.Find(id);
        if (t==null)return NotFound();
        t.Foods = null;
        var del=_db.Foods.IgnoreAutoIncludes().Where(x => x.Categoryid == id).ToList();
        _db.RemoveRange(del);
        _db.Remove(t);
            _db.SaveChanges();
            return Ok();
        }
    }
}
