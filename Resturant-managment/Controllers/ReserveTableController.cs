using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveTableController : ControllerBase
    {
        private readonly RmDbContext _db;
        private readonly UserManager<RestaurantIdentity> _userManager;

        public  ReserveTableController(RmDbContext db, UserManager<RestaurantIdentity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Post(ReserveTable r)
        {
            _db.Add(r);
            _db.SaveChangesAsync();
            return Ok(r.id);
        }

        [HttpGet("{id}")]
        public ActionResult<ReserveTable> Get(int id)
        {
            var result = _db.ReserveTables.Find(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var o = _db.ReserveTables.Find(id);
            if (o == null) return NotFound();
            _db.Remove(o);
            _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(ReserveTable r)
        {
            if (r.id == 0) return NotFound();
            _db.Update(r);
            _db.SaveChangesAsync();
            return Ok(r.id);
        }
        [Authorize]
        [HttpGet("GetUserActiveReserveTables")]
        public async Task<List<ReserveTable>> GetReserveTable()
        {

            var email = User.FindFirst("sub")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
             var result=_db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id)
                .Where(x =>
            
                (x.ReserveTime.ReserveTime.AddHours(x.ExpireHours)>=DateTime.Now)
            );
          
            return result.ToList() ;
        }

        [HttpGet("GetUserActiveReserveTablesByRestaurant")]
        public async Task<List<ReserveTable>> GetUserReserveTableByRestaurant(int restaurantid)
        {

            var email = User.FindFirst("sub")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var result = _db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id)
               .Where(x =>

               (x.ReserveTime.ReserveTime.AddHours(x.ExpireHours) >= DateTime.Now)
           ).Where(x => x.Table.RestaurantId==restaurantid);

            return result.ToList();
        }

        [HttpGet("GetReserveTablesByRestaurant")]
        public async Task<List<ReserveTable>> GetReserveTableByRestaurant(int restaurantid)
        {

            var result = _db.ReserveTables.Where(x => x.Table.RestaurantId == restaurantid)
                .Where(x =>check(x));

            return result.ToList();
        }
        private bool check(ReserveTable x)
        {
            var s = DateTime.Today;
            var e = DateTime.Today.AddDays(1);
            return (x.ReserveTime.ReserveTime >= s && x.ReserveTime.ReserveTime <= e);
        }
        [Authorize]
        [HttpGet("GetUserReserveTables")]
        public async Task<List<ReserveTable>> GetUserReserveTableHistory()
        {

            var email = User.FindFirst("sub")?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var result = _db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id)

           ;

            return result.ToList();
        }
    }

}
