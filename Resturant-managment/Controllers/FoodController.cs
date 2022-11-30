using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly RmDbContext _db;

        public FoodController(RmDbContext db)
        {
           _db = db;
        }
        [HttpGet]
        public List<Food> Get()
        {
            return _db.Foods.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Food Get(int id)
        {
            return _db.Foods.Find(id);
        }

        // POST api/values
        [HttpPost]
        public Food Post([FromBody]Food value)
        {
            _db.Foods.Add(value);
            _db.SaveChangesAsync();
            return value;

        }
        [HttpPost("PostRange")]
        public ActionResult<List<Food>> PostRange([FromBody] List<Food> value)
        {
            try
            {
                _db.Foods.AddRange(value);
                _db.SaveChangesAsync();
                return Ok(value);
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<Food> Put(Food val)
        {
            if (val.id == 0) return NotFound();
            
            _db.Foods.Update(val);
            _db.SaveChangesAsync();
            return Ok(val);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var t = _db.Foods.Find(id);
            if (t==null)
            {
                return NotFound();
            }

            _db.Remove(t);
            _db.SaveChangesAsync();
            return Ok();
        }
    }
}

