using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;
namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly RmDbContext _db;

        public FoodController(RmDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public List<Food> Get()
        {
            return _db.Foods.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Food> Get(int id)
        {
            var res = _db.Foods.Find(id);
            if (res == null) return NotFound();
            res.Image = null;
            if(res.Photo!=null)
            res.Photo.Img = "";
            return res;
        }

        // POST api/values
        [HttpPost]
        public Food Post([FromBody] Food value)
        {

            var p=new Photo { Img=value.Image??""};
            value.Image = null;
            value.Photo = p;
            _db.Foods.Add(value);
            _db.SaveChanges();
            return value;
           

        }
        [HttpPost("PostRange")]
        public ActionResult<List<Food>> PostRange([FromBody] List<Food> value)
        {
            try
            {
                var u = new Utils(_db);

                value.ForEach(x => {
                    x.Image = null;
                    var p = string.IsNullOrEmpty(x.Image) ? null : new Photo { Img = x.Image ?? "" };
                    x.Photo = p;
                });
                _db.Foods.AddRange(value);
                _db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<Food> Put([FromBody]Food food)
        {
            if (food.id == 0) return NotFound();
           
            _db.Foods.Update(food);
            _db.SaveChanges();
            return Ok(food);
            
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var t = _db.Foods.Find(id);
            if (t == null)
            {
                return NotFound();
            }

            _db.Remove(t);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("RestaurantFoodList{RestaurantId}")]
        public List<Food> RestaurantFoodList(int RestaurantId)
        {
            return _db.Foods.Where(x => x.Category != null ? x.Category.RestaurantId == RestaurantId : false).ToList();
        }
        
    }
}

