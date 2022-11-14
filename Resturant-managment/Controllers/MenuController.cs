using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_managment.Models;

namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly RmDbContext _db;
        public MenuController(RmDbContext db)
        {
            _db = db;
        }
        [HttpGet("{RestaurantId}")]
        public IEnumerable<Menu> GetWholeMenus(int RestaurantId)
        {
            var menus = _db.Menus.Where(x => x.Restaurantid == RestaurantId);
            
            foreach (var menu in menus)
            {
                menu.Categories = GetMenuCategories(menu.id);
                foreach (var category in menu.Categories)
                {
                    category.Foods = GetCategoryFoods(category.id);
                }
            }
            return menus.ToList();
        }
        [HttpPost]
        public ActionResult<Menu> Post([FromBody]Menu value)
        {
            _db.Add(value);
            _db.SaveChangesAsync();
            return Created("",value);
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put( [FromBody] Menu menu)
        {
            _db.Menus.Update(menu);
            _db.SaveChangesAsync();
            return Ok();
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var t=_db.Menus.Find(id);
            if (t == null) return NotFound();
            _db.Menus.Remove(t);
            _db.SaveChangesAsync();
            return Ok();
        }


        private List<Food> GetCategoryFoods(int catId) => _db.Foods.Where(x => x.Categoryid == catId).ToList();
        private List<Category> GetMenuCategories(int menuId) => _db.Categories.Where(x => x.MenuId == menuId).ToList();

    }
}

