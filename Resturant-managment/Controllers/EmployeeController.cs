using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
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

        [Authorize(Roles ="Admin")]
        [HttpGet("EmployeeOfRestaurant")]
        public List<Employee> GetByRestaurant(int restaurantid)
        {
            return _db.Employees.Where(x => x.restaurantid == restaurantid).ToList();
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public ActionResult Put(Employee e)
        {
            _db.Update(e);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("byjobtype")]
        public ActionResult<List<Employee>> GetByJobType(int restaurantid , jobtype jobtype)
        {
            var r = _db.Employees.Where(x => x.restaurantid == restaurantid && x.jobtype == jobtype).ToList();
            return r;
        }
        [HttpGet("FindByPosition")]
        public ActionResult<List<Employee>> FindByPosition(int restaurantid , string position)
        {
            var r = _db.Employees.Where(x=> x.restaurantid == restaurantid && x.position == position).ToList();
            return r;
        }
    }
}
