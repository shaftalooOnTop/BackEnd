using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RmDbContext _db;

        public EmployeeController(RmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult<Employee> add(Employee e)
        {
            _db.Add(e);
            _db.SaveChanges();
            return Ok(e);
        }

        [HttpDelete("id")]
        public ActionResult<Employee> Delete(int id)
        {
            var en = _db.Employees.Find(id);
            if (en == null) return NotFound();
            _db.Remove(en);
            _db.SaveChanges();
            return Ok();

        }

        [HttpGet("employeeid")]
        public ActionResult<Employee> Get(int id)
        {
            var e = _db.Employees.Find(id);
            if(e == null) return NotFound();
            return Ok(e);
        }

        [HttpGet("EmployeeOfRestaurant")]
        public List<Employee> GetByRestaurant(int restaurantid)
        {
            return _db.Employees.Where(x => x.restaurantid == restaurantid).ToList();
        }

        [HttpPut]
        public ActionResult Put(Employee e)
        {
            _db.Update(e);
            _db.SaveChanges();
            return Ok();
        }
    }
}
