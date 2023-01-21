using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant_managment.Models;

namespace Resturant_managment;

public class RmDbContext:IdentityUserContext<RestaurantIdentity>
{
    public RmDbContext(DbContextOptions<RmDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        //IdentityRole
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
        modelBuilder.Entity<IdentityRole>().HasKey(p => new { p.Id,p.Name});


    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<RestaurantTable> RestaurantTables { get; set; }
    public DbSet<resrvetime> Resrvetimes { get; set; }
    public DbSet<ReserveTable> ReserveTables { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Photo> PhotoTable { get; set; }


    //public DbSet<IdentityRole> IdentityRole { get; set; }


    public DbSet<Photo> Photos { get; set; }
    public DbSet<EntranceMangment> EntranceMangments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<LandingPage> LandingPages { get; set; }
    public DbSet<ThemeOfTable> ThemeOfTables { get; set; }
    public DbSet<Poll> Polls { get; set; }
    public DbSet<primium> Primiums { get; set; }
}