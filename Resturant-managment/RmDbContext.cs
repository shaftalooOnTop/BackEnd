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

        modelBuilder.Entity<Food>()
            .HasMany(p => p.Orders)
            .WithMany(p => p.Foods)
            .UsingEntity(j => j.ToTable("FoodOrders"));

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<RestaurantTable> RestaurantTables { get; set; }
    public DbSet<resrvetime> Resrvetimes { get; set; }
    public DbSet<ReserveTable> ReserveTables { get; set; }
    //public DbSet<FoodOrder> FoodOrders { get; set; }

   
}