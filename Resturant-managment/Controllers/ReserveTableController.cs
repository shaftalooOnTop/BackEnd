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
    [Authorize]
    public class ReserveTableController : ControllerBase
    {
        private readonly RmDbContext _db;
        private readonly UserManager<RestaurantIdentity> _userManager;
        public ReserveTableController(RmDbContext db, UserManager<RestaurantIdentity> userManager)
        {
            _db = db;
            _userManager = userManager;

        }

        private RestaurantIdentity GetUser()
        {
            var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return _userManager.FindByEmailAsync(email).Result;
        }
        [HttpPost]
        public ActionResult Post(ReserveTable r)
        {
            var user = GetUser();
            r.RestaurantIdentity = user;
            r.RestaurantIdentityId = user.Id;
            _db.Add(r);
            _db.SaveChanges();
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
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(ReserveTable r)
        {
            var user = GetUser();
            r.RestaurantIdentity = user;
            r.RestaurantIdentityId = user.Id;
            if (r.id == 0) return NotFound();
            _db.Update(r);
            _db.SaveChanges();
            return Ok(r.id);
        }
        [HttpGet("GetUserActiveReserveTables")]
        public async Task<List<ReserveTable>> GetReserveTable()
        {

            var user = GetUser();
            var result = _db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id)
                .Where(x =>

                (x.ReserveTime.ReserveTime.AddHours(x.ExpireHours) >= DateTime.Now)
            );

            return result.ToList();
        }

        [HttpGet("GetUserActiveReserveTablesByRestaurant")]
        public List<ReserveTable> GetUserReserveTableByRestaurant(int restaurantid)
        {

            var user = GetUser();

            var result = _db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id)
               .Where(x =>

               (x.ReserveTime.ReserveTime.AddHours(x.ExpireHours) >= DateTime.Now)
           ).Where(x => x.Table.RestaurantId == restaurantid);

            return result.ToList();
        }

        [HttpGet("GetReserveTablesByRestaurant")]
        public List<ReserveTable> GetReserveTableByRestaurant(int restaurantid)
        {
            var result = _db.ReserveTables.Where(x => x.Table.RestaurantId == restaurantid)
                .Where(x => check(x));
            return result.ToList();
        }
        [HttpGet("GetActiveReserveTablesByRestaurant")]
        public ActionResult<List<RestaurantTable>> GetActiveReserveTablesByRestaurant(int restauranId, DateTime from ,DateTime to) {
            var result = _db.RestaurantTables.Where(x => x.ReserveTables
              .All(y => y.ReserveTime.ReserveTime > from
              &&
              y.ReserveTime.ReserveTime.AddHours(y.ExpireHours) < to)).ToList();
            return result;

        }
        private bool check(ReserveTable x)
        {
            var s = DateTime.Today;
            var e = DateTime.Today.AddDays(1);
            return (x.ReserveTime.ReserveTime >= s && x.ReserveTime.ReserveTime <= e);
        }
        [HttpGet("GetUserReserveTables")]
        public async Task<List<ReserveTable>> GetUserReserveTableHistory()
        {

            var user = GetUser();
            var result = _db.ReserveTables.Where(x => x.RestaurantIdentityId == user.Id);

            return result.ToList();
        }
    }

}
