using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly RmDbContext _db;

        public CommentController(RmDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _db.Comments.ToList();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        // POST: api/Comment
        [HttpPost]
        public ActionResult Post([FromBody] Comment value)
        {
            _db.Add(value);
            int n=_db.SaveChanges();
            Console.Write(n);
            return Created("", value);
        }

        // PUT: api/Comment/5
        [HttpPut]
        public void Put([FromBody] Comment value)
        {
            _db.Update(value);
            _db.SaveChanges();
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t = _db.Comments.Find(id);
            if (t == null) return NotFound();
            _db.Remove(t);
            _db.SaveChanges();
            return Ok();
        }
    }
}
