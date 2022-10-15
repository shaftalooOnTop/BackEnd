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
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private List<Food> GetCategoryFoods(int catId) => _db.Foods.Where(x => x.Categoryid == catId).ToList();
        private List<Category> GetMenuCategories(int menuId) => _db.Categories.Where(x => x.Menuid == menuId).ToList();

    }
}

