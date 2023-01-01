using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    }).AddRoles<IdentityRole>()
                   
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<RmDbContext>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JwtService>();

builder.Services.AddDbContext<RmDbContext>(options => options.
    UseLazyLoadingProxies().
    UseSqlServer("Data Source=efc4055b-632b-4cd9-8b5d-e1a9aaf42e5b.hsvc.ir,32284;Database=shaftalooV1;Application Name=app;Integrated Security=false;User ID=sa;Password=iTd8ldXElyXXFu0rWWITWCqQqpOEs153;MultipleActiveResultSets=True"));
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.Configure<MailSetting>(config.GetSection("MailSettings"));
builder.Services.AddCors();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = config["Jwt:Audience"],
            ValidIssuer = config["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"])
            )
        };
    });
builder.Services.AddSingleton(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
//app.UseSwagger();__
}//                  |
app.UseSwagger();//<-|

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

