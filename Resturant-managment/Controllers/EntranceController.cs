using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        private readonly RmDbContext _db;

        public EntranceController(RmDbContext db)
        {
            _db = db;
        }

        [HttpGet("EmployeesInTheRestaurant")]
        
        public ActionResult<List<Employee>> EmployeesPresent(int restaurantid , DateTime from, DateTime to )
        {
            var result = _db.Employees.Where(x => x.restaurantid == restaurantid).
            Where(x => x.entranceMangments.Any(x => x.enter >= from && (x.leave ?? DateTime.Now) <= to)).ToList();
            
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<EntranceMangment> add(EntranceMangment e)
        {
            _db.Add(e);
            _db.SaveChanges();
            return Ok(e);
        }

        [HttpDelete("id")]
        public ActionResult<EntranceMangment> Delete(int id)
        {
            var en = _db.EntranceMangments.Find(id);
            if (en == null) return NotFound();
            _db.Remove(en);
            _db.SaveChanges();
            return Ok();

        }

        [HttpGet("PresentOfAEmployee")]
        public ActionResult<EntranceMangment> PresentOfEmployee(int employeeid)
        {
            var p = _db.EntranceMangments.Where(x=>x.IdentityId == employeeid).ToList();
            return Ok(p);
        }

        [HttpPut]
        public ActionResult Put(EntranceMangment entrance)
        {
            _db.Update(entrance);
            _db.SaveChanges();
            return Ok();
        }
    }
    
}
