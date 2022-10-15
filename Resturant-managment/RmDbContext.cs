using Microsoft.EntityFrameworkCore;
using Resturant_managment.Models;

namespace Resturant_managment;

public class RmDbContext:DbContext
{
    public RmDbContext(DbContextOptions<RmDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }

}