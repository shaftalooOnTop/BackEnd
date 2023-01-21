using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimiumController : ControllerBase
    {
        private readonly RmDbContext _db;

        public PrimiumController(RmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Post(primium value)
        {
            _db.Add(value);
            _db.SaveChanges();
           
            var r = _db.Restaurant.Find( value.restaurantid);
            r.primium_ex = value.expiretime;
            _db.Restaurant.Update(r);
            _db.SaveChanges();
            return Ok(value);
        }

        [HttpPut]
        public ActionResult Put(primium value)
        {
            if (value.id == 0) return NotFound();
            _db.Update(value);
            _db.SaveChanges();
            var r = _db.Restaurant.Find(value.restaurantid);
            r.primium_ex = value.expiretime;
            _db.Restaurant.Update(r);
            _db.SaveChanges();
            return Ok();
        }

    }
}
