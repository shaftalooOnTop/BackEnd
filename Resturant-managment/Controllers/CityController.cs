using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly RmDbContext _db;

        public CityController(RmDbContext db)
        {
            _db = db;
        }
        // GET: api/City
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _db.Cities.ToList();
        }

        // GET: api/City/5
        [HttpGet("{name}")]
        public City Get(string name)
        {
            return _db.Cities.FirstOrDefault(x=>x.CityName==name);
        }

        // POST: api/City
        [HttpPost]
        public ActionResult<City> Post([FromBody] City value)
        {
            _db.Add(value);
            _db.SaveChanges();
            return Ok(value);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] City value)
        {
            _db.Update(value);
            _db.SaveChanges();
            return Ok();
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public ActionResult<City> Delete(int id)
        {
            var city = _db.Cities.Find(id);
            if (city == null) return NotFound();
            _db.Remove(city);
            _db.SaveChanges();
            return Ok(city);

        }
        [HttpGet("FavoriteFood")]
        public ActionResult<Restaurant> FavoriteFoodByCategory(int RestaurantId)
        {
            var restaurants = _db.Restaurant.FirstOrDefault(x => x.id == RestaurantId);
            if (restaurants == null) return NotFound();
            var result = _db.Foods.Where(x => x.Category.RestaurantId == RestaurantId);
            var t = _db.Orders.Where(r => r.restaurantId == RestaurantId)
               .SelectMany((arg) => arg.Foods).ToList()
               .GroupBy(x => x.id)
               .ToDictionary(x => x.Key, x => x.Count());

            var ls = new List<KeyValuePair<Food, int>>();
            result
                .ToList();
            foreach (var i in result)
            {
                if (!t.ContainsKey(i.id)) continue;
                var tmp = new KeyValuePair<Food, int>(i, t[i.id]);
                ls.Add(tmp);
            }
            ls.GroupBy(x => x.Key.Categoryid);
            ls.Sort((x, y) => x.Value - y.Value);
            restaurants.Favorites = ls.Select(x => x.Key).First();
            return Ok(restaurants);

        }
    }
}
