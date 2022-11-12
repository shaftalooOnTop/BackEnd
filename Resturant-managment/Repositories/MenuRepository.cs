using Resturant_managment.Models;

namespace Resturant_managment.Repositories;

public class MenuRepository:IDisposable
{
    private readonly RmDbContext _db;

    public MenuRepository(RmDbContext db)
    {
        _db = db;
    }

    public List<Menu> GetAllMenus()
    {
        return _db.Menus.ToList();
    }

    public IEnumerable<Menu> GetRestaurantMenu(int restaurantId)
    {
        var t=_db.Menus.Where(x => x.Restaurantid == restaurantId);
        return t;
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}