using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void Post([FromBody]Food value)
        {
            _db.Foods.Add(value);
            _db.SaveChangesAsync();
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
        public ActionResult<Food> Put(Food value)
        {
            if (value.id == 0) return NotFound();
            
            _db.Foods.Update(value);
            _db.SaveChangesAsync();
            return Ok(value);
        }
        
    }
}

