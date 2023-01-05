using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly RmDbContext _db;

        public PollController(RmDbContext db)
        {
            _db = db;
        }

        [HttpGet("question")]
        public List<string> question()
        {
            string description = "please rate this fild whith number 1 to 5 in order :very bad , bad, medium , good or very good, 1 means very bad and goes on ";
            string title1 = "service quality";
            string title2 = "food quality";
            string title3 = "Personnel Behavior";
            string title4 = "order accuracy";
            string title5 = "restaurant atmosphere";
            string title6 = "find room in parking lot";
            string title7 = "cleanliness of restaurant";
            List<string> q = new List<string>();
            q.Add(description);
            q.Add(title1);
            q.Add(title2);
            q.Add(title3);
            q.Add(title4);
            q.Add(title5);
            q.Add(title6);
            q.Add(title7);
            return q;
        }
        [HttpGet("ByRestauntId")]
        public ActionResult<List<Poll>> get(int restaurantid)
        {
            var p = _db.Polls.Where(x=>x.restaurantid == restaurantid).ToList();
            return Ok(p);
        }

        [HttpGet("id")]
        public Poll? Get(int id)
        {
            return _db.Polls.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Poll value)
        {
            _db.Add(value);
            _db.SaveChanges();
            return Ok(value);
        }
       
        [HttpPut]
        public ActionResult Put(Poll value)
        {
            if (value.id == 0) return NotFound();
            _db.Update(value);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Poll> Delete(int id)
        {
            var p = _db.Polls.Find(id);
            if (p == null) return NotFound();
            _db.Remove(p);
            _db.SaveChanges();
            return Ok(p);
        }

        [HttpGet("result")]
        public ActionResult<List<Poll>> result(int restaurantid)  
        {
            var r1 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x=>x.score1);
            var r2 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score2);
            var r3 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score3);
            var r4 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score4);
            var r5 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score5);
            var r6 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score6);
            var r7 = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList().Average(x => x.score7);
            double[] r = new double[7];
            r[0] = r1;
            r[1] = r2;
            r[2] = r3;
            r[3] = r4;
            r[4] = r5;
            r[5] = r6;
            r[6] = r7;
            var d = r.Average(r => r);
            var p = _db.Polls.Where(x => x.restaurantid == restaurantid).ToList();
            foreach(var x in p)
            {
                x.restaurantrate = d;
            }
            var a = _db.Restaurant.Find(restaurantid);
            a.rate = d;
            _db.Update(a);
            _db.SaveChanges();
            return Ok(r);
        }
       
    }
}
