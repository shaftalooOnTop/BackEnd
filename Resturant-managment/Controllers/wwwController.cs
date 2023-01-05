
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Resturant_managment.Models;

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


        [HttpGet("ImgGet/{id}")]
        public IActionResult Get(int id)
        {
            var value = _db.Photos.Find(id);
            if (value == null) return NotFound();
            Byte[] b1 ;
            if (value.Img.Contains(','))
             b1= Convert.FromBase64String(value.Img.Split(',')[1]);
            else
                b1 = Convert.FromBase64String(value.Img);
            return File(b1, "image/*");
        }


        // POST: api/www
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            var b1 = Convert.FromBase64String(value);
            return File(b1, "image/*");

        }
        [HttpPost("post2")]
        public ActionResult Post2([FromBody] FormFile value)
        {
            string uploads =_appEnvironment.WebRootPath;
     
            
                if (value.Length > 0)
                {
                    string filePath = Path.Combine(uploads, value.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    value.CopyTo(fileStream);
                    
                }

            return Ok();
           
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
