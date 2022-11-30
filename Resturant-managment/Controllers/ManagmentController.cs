using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;
using Resturant_managment.Models.Managment;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentController : ControllerBase
    {


        private readonly RmDbContext _db;
        public ManagmentController(RmDbContext db)
        {
            _db = db;
        }
        // GET: api/Managment
        [HttpGet("GetDailyProfit{restaurantId}")]
        public Profit GetProfits(int restaurantId)
        {
            var prof = new Profit();
            var orders = _db.Orders.Where(x => x.restaurantId == restaurantId).ToList();
            var d = DateTime.Now;

            DateTime StartOfTheDay = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            DateTime EndOfTheDay = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
            prof.DailyProfit = ProfitByDate(orders, StartOfTheDay, EndOfTheDay);

            DateTime StartOfTheMonth = new DateTime(d.Year, d.Month, 1, 0, 0, 0);
            var daysInMonth = DateTime.DaysInMonth(d.Year, d.Month);
            DateTime EndOfTheMonth = new DateTime(d.Year, d.Month, daysInMonth, 23, 59, 59);

            var firstDayOfTheYear = new DateTime(d.Year, 1, 1);
            var lastDayOfTheYear = new DateTime(d.Year, 12, 31);




            return prof;
        }
        private long ProfitByDate(List<Order> orders, DateTime from, DateTime to)
        {
            long result = orders.Where(x => x.DateCreated >= from && x.DateCreated <= to).Sum(x => x.Foods.Sum(y => (long)y.Price));
            return result;
        }
    }
}
