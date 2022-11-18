using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return _db.Categories.ToList();
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
            return Ok(_db.Add(value));
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult Put(Category value)
        {
            if (value.id == 0) return NotFound();
            _db.Update(value);
            _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t=_db.Categories.Find(id);
if (t==null)return NotFound();
            _db.Remove(t);
            _db.SaveChangesAsync();
            return Ok();
        }
    }
}
