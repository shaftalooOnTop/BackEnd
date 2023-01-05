using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Resturant_managment;
using Resturant_managment.Models;
using Resturant_managment.Services;

namespace RestaurantTest;

public class UserUnitTest
{
    private readonly Mock<RmDbContext> _db;
    private readonly JwtService _jwtService;
    private readonly UserController _userController;
    UserUnitTest()
    {
        //DbContextOptionsBuilder<RmDbContext> options = new();
        //var options1 = options.
        //UseLazyLoadingProxies().
        //UseSqlServer("Data Source=efc4055b-632b-4cd9-8b5d-e1a9aaf42e5b.hsvc.ir,32284;Database=shaftalooV1;Application Name=app;Integrated Security=false;User ID=sa;Password=iTd8ldXElyXXFu0rWWITWCqQqpOEs153;MultipleActiveResultSets=True").

        //Options;
        //_db = new RmDbContext(options1);

        var issuer = "https://localhost:7099";
        var audience = "https://localhost:7099";
        var key = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9";
        var role =  new Mock<RoleManager<IdentityRole>>();
        var user =  new Mock<UserManager<RestaurantIdentity>>();
        _jwtService = new JwtService(issuer,audience,key);
        _db = new Mock<RmDbContext>().SetupAllProperties();

        _userController = new UserController(role.Object,user.Object,_jwtService,_db.Object);

      
    }
    [Fact]
    public void PostUser()
    {

    }
    
    [Fact]
    public void PostRestaurantAdmin()
    {

    }
}
