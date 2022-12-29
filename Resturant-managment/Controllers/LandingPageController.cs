using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Resturant_managment.Models;


namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class LandingPageController : ControllerBase
    {
        private readonly RmDbContext _db;
        public LandingPageController (RmDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<LandingPage> get(int id)
        {
            return Ok(_db.LandingPages.Find(id));
        }

        [HttpPost]
        public ActionResult<LandingPage> add(LandingPage e)
        {
            _db.Add(e);
            _db.SaveChanges();
            return Ok(e);
        }
        [HttpDelete("byid")]
        public ActionResult<LandingPage> delete(int id)
        {
            var result = _db.LandingPages.Find(id);
            _db.LandingPages.Remove(result);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult<LandingPage> change(LandingPage v)
        {
            if (v.id == 0) return NotFound();
            _db.Update(v);
            _db.SaveChanges();
            return Ok();
        }

    }
}
