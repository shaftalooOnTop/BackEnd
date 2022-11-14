using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Resturant_managment;
using Resturant_managment.Models;
using Resturant_managment.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddIdentityCore<RestaurantIdentity>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<RmDbContext>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JwtService>();

builder.Services.AddDbContext<RmDbContext>(options => options.
    UseLazyLoadingProxies().
    UseSqlite("Data Source=Application.db;Cache=Shared"));
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);  
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();
app.UseStaticFiles();   
app.UseAuthorization();
app.UseCors(builder1 =>
{
    builder1.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.Run();

