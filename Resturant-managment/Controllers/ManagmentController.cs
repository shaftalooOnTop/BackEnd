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
            prof.MonthlyProfit = ProfitByDate(orders, StartOfTheDay, EndOfTheDay);

            var firstDayOfTheYear = new DateTime(d.Year, 1, 1);
            var lastDayOfTheYear = new DateTime(d.Year, 12, 31);
            prof.MonthlyProfit = ProfitByDate(orders, firstDayOfTheYear, lastDayOfTheYear);

            return prof;
        }

        [HttpGet("GetBusyHours")]
        public BusyHours BusyHours(int restaurantId)
        {
            var busy = new BusyHours();
            var orders = _db.Orders.Where(x => x.restaurantId == restaurantId).ToList();
            var d = DateTime.Now;

            DateTime StartOfTheDay = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            DateTime EndOfTheDay = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
            busy.DayHour = OrdersHours(orders, StartOfTheDay, EndOfTheDay);

            DateTime StartOfTheMonth = new DateTime(d.Year, d.Month, 1, 0, 0, 0);
            var daysInMonth = DateTime.DaysInMonth(d.Year, d.Month);
            DateTime EndOfTheMonth = new DateTime(d.Year, d.Month, daysInMonth, 23, 59, 59);
            busy.MonthHour = OrdersHours(orders, StartOfTheDay, EndOfTheDay);

            var firstDayOfTheYear = new DateTime(d.Year, 1, 1);
            var lastDayOfTheYear = new DateTime(d.Year, 12, 31);
            busy.WeekHour = OrdersHours(orders, StartOfTheDay, EndOfTheDay);


            return busy;
        }

        [HttpGet("GetFoodSellByFoods")]
        public ActionResult<Dictionary<Food,int>> GetFoodSellByFoods(int restaurantId,DateTime from,DateTime to)
        {
            var restaurantOrders = _db.Orders.Where(x => x.DateCreated >= from && x.DateCreated <= to).Select(x => x.Foods);
            if (restaurantOrders == null) return NotFound();
            var f = FlatenList(restaurantOrders).GroupBy(x => x.id).ToDictionary(x => x.Key, y => y.Count());
            var restaurantFoods = _db.Foods.Where(x => x.Category==null?false:x.Category.RestaurantId == restaurantId).ToDictionary(x=>x.id,y=>y);
            return Ok(
                f.Select(x =>new KeyValuePair<Food, int>(restaurantFoods[x.Key],x.Value))
                );

        }

        [HttpGet("RestaurantFoodListByOrder")]
        public List<Food> RestaurantFoodListByOrder(int RestaurantId, DateTime from, DateTime to)
        {
            Dictionary<int, int> foodDict = new();

            _db.Orders.Where(x => x.id == RestaurantId).Where(x => x.DateCreated >= from && x.DateCreated <= to)
                .Select(x => x.Foods).ToList()
                .ForEach(delegate (List<Food> x)
                {
                    if (x == null) return;
                    FlatenList(foodDict, x);
                });

            var foodsList = _db.Foods.Where(x => foodDict.ContainsKey(x.id)).ToList();
            foodsList.Sort((x, y) => foodDict[x.id] - foodDict[y.id]);
            return foodsList;
        }

        [HttpGet("getTaxes")]
        public Tax TotalTax(int restaurantId)
        {
            var d = DateTime.Now;
            var firstDayOfTheYear = new DateTime(d.Year, 1, 1);
            var lastDayOfTheYear = new DateTime(d.Year, 12, 31);
            GetFoodSellByFoods(restaurantId, firstDayOfTheYear, lastDayOfTheYear);
            return new Tax();
        }

        private void FlatenList(Dictionary<int, int> foodDict, IEnumerable<Food> foods)
        {
            foreach (var i in foods)
                foodDict[i.id]++;
        }
        private List<Food> FlatenList(IEnumerable<IEnumerable<Food>> foods)
        {
            List<Food> foods1 = new();
            foreach (var i in foods)foreach (var j in i) foods1.Add(j);
            return foods1;
       
        }
        private long ProfitByDate(List<Order> orders, DateTime from, DateTime to)
        {
            long result = orders.Where(x => x.DateCreated >= from && x.DateCreated <= to).Sum(x => x.Foods.Sum(y => (long)y.Price));
            return result;
        }
        private List<int> OrdersHours(List<Order> orders, DateTime from, DateTime to)
        {
            var r = orders.Where(x => x.DateCreated >= from && x.DateCreated <= to)
                  .Select(x => x.DateCreated.Hour)
                  .GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count()).ToList();
            r.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return r.Select(x => x.Key).ToList();
        }


    }
}
