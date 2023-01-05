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
    public class TagController : Controller
    {
        private readonly RmDbContext _db;

        public TagController(RmDbContext db)
        {
            _db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _db.Tags.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Tag Get(int id)
        {
            return _db.Tags.Find(id);
        }
        [HttpDelete("GetUniqueTagsByCity/{cityId}")]

        public ActionResult<List<string>> GetUniqueTagsByCity(int cityId)
        {
            var result = _db.Tags.Where(r => r == null ? false : r.Restaurant.CityId == cityId).GroupBy(r => r.value).Select(t => t.Key).ToList();
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Tag value)
        {
            _db.Add(value);
            _db.SaveChanges();
            return Created("",value);
        }

        // PUT api/values/5
        [HttpPut]
        public Tag Put( [FromBody]Tag value)
        {
            _db.Update(value);
            _db.SaveChanges();
            return value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t = _db.Tags.Find(id);
            if (t == null) return NotFound();
            _db.Remove(t);
            _db.SaveChanges();
            return Ok(t);
        }
    }
}

