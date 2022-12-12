
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class wwwController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly RmDbContext _db;

        public wwwController(IWebHostEnvironment appEnvironment,RmDbContext db)
        {
            _appEnvironment = appEnvironment;
            _db = db;
        }
        // GET: api/www
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            var d=Directory.GetFiles(_appEnvironment.WebRootPath, "*.*", SearchOption.AllDirectories).ToList();
            
            return d;
        }

        // GET: api/www/5
        [HttpGet("Get/{name}")]
        public IActionResult Get(string name)
        {

            var b = System.IO.File.ReadAllBytes(Path.Combine(_appEnvironment.WebRootPath, name));   // You can use your own method over here.         
            return File(b, "image/*");
        }

        // POST: api/www
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/www/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/www/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
