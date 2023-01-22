using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet("GetProfit/{restaurantId}")]
        public Profit GetProfits(int restaurantId)
        {

            var prof = new Profit();
            prof.DailyProfit = 1;
            prof.MonthlyProfit = 2;
            prof.YearlyProfit = 3;
            if (restaurantId == 7) return prof;
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
            prof.YearlyProfit = ProfitByDate(orders, firstDayOfTheYear, lastDayOfTheYear);

            return prof;
        }
        [Authorize]

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
            busy.MonthHour = OrdersHours(orders, StartOfTheMonth, EndOfTheMonth);

            var firstDayOfTheYear = new DateTime(d.Year, 1, 1);
            var lastDayOfTheYear = new DateTime(d.Year, 12, 31);
            busy.WeekHour = OrdersHours(orders, firstDayOfTheYear, lastDayOfTheYear);


            return busy;
        }
        [Authorize]
        [HttpGet("GetFoodSellByFoods")]
        public ActionResult<Dictionary<Food, int>> GetFoodSellByFoods(int restaurantId, DateTime from, DateTime to)
        {
            var restaurantOrders = _db.Orders.Where(x => x.DateCreated >= from && x.DateCreated <= to).Where(x => x.restaurantId == restaurantId).Select(x => x.Foods).ToList();
            if (restaurantOrders == null) return NotFound();
            var f = FlatenList(restaurantOrders).GroupBy(x => x.id).ToDictionary(x => x.Key, y => y.Count());
            var restaurantFoods = _db.Foods.Where(x => x.Category == null ? false : x.Category.RestaurantId == restaurantId).ToDictionary(x => x.id, y => y);
            return Ok(
                f.
                Select(x => new KeyValuePair<Food, int>(restaurantFoods[x.Key], x.Value))
                .OrderByDescending(x => x.Value).ToArray()
                );

        }
        [Authorize]
        [HttpGet("RestaurantFoodListByOrder")]
        public List<Food> RestaurantFoodListByOrder(int RestaurantId, DateTime from, DateTime to)
        {
            Dictionary<int, int> foodDict = new();

            var x1 = _db.Orders.Where(x => x.restaurantId == RestaurantId).Where(x => x.DateCreated >= from && x.DateCreated <= to).ToList();
            x1.Select(x => x.Foods).ToList()
            .ForEach(delegate (List<Food> x)
            {
                if (x == null) return;
                FlatenList(foodDict, x);
            });

            var foodsList = _db.Foods.ToList().Where(x => foodDict.ContainsKey(x.id)).ToList();
            foodsList.Sort((x, y) => foodDict[x.id] - foodDict[y.id]);
            return foodsList;
        }
        [Authorize]
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
                if (foodDict.ContainsKey(i.id))
                    foodDict[i.id]++;
                else
                    foodDict[i.id] = 1;
        }
        private List<Food> FlatenList(IEnumerable<IEnumerable<Food>> foods)
        {
            List<Food> foods1 = new();
            foreach (var i in foods)
                foreach (var j in i)
                {
                    j.Image = null;
                    foods1.Add(j);
                }
            return foods1;

        }
        private double ProfitByDate(List<Order> orders, DateTime from, DateTime to)
        {
            var result = orders.Where(x => x.DateCreated >= from && x.DateCreated <= to)
                .Sum(x => x.Foods.Sum(y => (long)y.Price)) * .3;
            return result;
        }
        private List<int> OrdersHours(List<Order> orders, DateTime from, DateTime to)
        {
            var r = orders.Where(x => x.DateCreated >= from && x.DateCreated <= to)
                  .Select(x => x.DateCreated.Hour)
                  .GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count()).ToList();
            return r.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }

        [Authorize]
        [HttpGet("GetFoodSellChartDataDay/{restaurantId}")]
        public List<FoodSell> GetFoodSellChartDataDay(int restaurantId)
        {
            var d = DateTime.Now;

            DateTime StartOfTheDay = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            DateTime EndOfTheDay = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
            var t=_db.Orders.Where(x => x.restaurantId == restaurantId)
               .Where(x => x.DateCreated >= StartOfTheDay && x.DateCreated <= EndOfTheDay)
               .ToArray()
               .SelectMany(x => x.Foods).GroupBy(x => x.id)
               .ToDictionary(x => x.Key, x => x.Count()).ToList();
          
            var foodDic = _db.Foods.Select(x => new { x.id, x.Name }).ToDictionary(x => x.id, x => x.Name);
            var l = new List<FoodSell>();
            foreach (var i in t)
            {
                var tmp = new FoodSell { FoodName=foodDic[i.Key],SellNubmer=i.Value};
                l.Add(tmp);
            }
            return l;
        }
        [Authorize]
        [HttpGet("GetFoodSellChartDataWeek/{restaurantId}")]
        public List<FoodSell> GetFoodSellChartDataWeek(int restaurantId)
        {
            var baseDate = DateTime.Now;
            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            var t = _db.Orders.Where(x => x.restaurantId == restaurantId)
               .Where(x => x.DateCreated >= thisWeekStart && x.DateCreated <= thisWeekEnd)
               .ToArray()
               .SelectMany(x => x.Foods).GroupBy(x => x.id)
               .ToDictionary(x => x.Key, x => x.Count()).ToList();

            var foodDic = _db.Foods.Select(x => new { x.id, x.Name }).ToDictionary(x => x.id, x => x.Name);
            var l = new List<FoodSell>();
            foreach (var i in t)
            {
                var tmp = new FoodSell { FoodName = foodDic[i.Key], SellNubmer = i.Value };
                l.Add(tmp);
            }
            return l;

        }
        [Authorize]
        [HttpGet("GetFoodSellChartDataMonth/{restaurantId}")]
        public List<FoodSell> GetFoodSellChartDataMonth(int restaurantId)
        {
            var d = DateTime.Now;

            DateTime StartOfTheMonth = new DateTime(d.Year, d.Month, 1, 0, 0, 0);
            var daysInMonth = DateTime.DaysInMonth(d.Year, d.Month);
            DateTime EndOfTheMonth = new DateTime(d.Year, d.Month, daysInMonth, 23, 59, 59);

            var t = _db.Orders.Where(x => x.restaurantId == restaurantId)
               .Where(x => x.DateCreated >= StartOfTheMonth && x.DateCreated <= EndOfTheMonth)
               .ToArray()
               .SelectMany(x => x.Foods).GroupBy(x => x.id)
               .ToDictionary(x => x.Key, x => x.Count()).ToList();

            var foodDic = _db.Foods.Select(x => new { x.id, x.Name }).ToDictionary(x => x.id, x => x.Name);
            var l = new List<FoodSell>();
            foreach (var i in t)
            {
                var tmp = new FoodSell { FoodName = foodDic[i.Key], SellNubmer = i.Value };
                l.Add(tmp);
            }
            return l;

        }
        [HttpGet("ExportRestaurant/{id}")]
        [Authorize]
        public Restaurant ExportRestaurant(int id)
        {
            return _db.Restaurant.Find(id);
        }
        [HttpGet("ExportUser/{id}")]
        [Authorize]
        public RestaurantIdentity ExportUser(string id)
        {
            return _db.Users.Find(id);
        }
        [HttpGet("getOrdersByStatus")]
        [Authorize]
        public List<Order> GetOrdersByStatus(DateTime From ,DateTime To ,Orderstatus stat , int restaurantid)
        {
            return
                _db.Orders
                .Where(c => c.DateCreated >= From && c.DateCreated <= To && c.stat == stat && c.restaurantId == restaurantid)
                .ToList();
        }
    }
}
