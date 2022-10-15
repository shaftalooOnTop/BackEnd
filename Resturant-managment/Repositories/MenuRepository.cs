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

    public IEnumerable<Menu> GetRestaurantMenu(int id)
    {
        var t = _db.Restaurant.ToList();
        Console.WriteLine(t);
        return _db.Menus.Where(x => x.id == id);
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}