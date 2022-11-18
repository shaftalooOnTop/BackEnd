using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using Resturant_managment.Models;
using Resturant_managment.Models.HTTPModels;

namespace Resturant_managment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly RmDbContext _db;
    private readonly IMapper _mapper;

    public RestaurantController(RmDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    [HttpGet]
    public ActionResult<List<Restaurant>> Get(string tag, int size = 10, int number = 0)
    {

        var restaurantList = _db.Restaurant.ToList().Skip(size * number).Take(size);
        restaurantList.All(x => { x.Comments = null; return true; });
        if (tag == "all")
            return Ok(restaurantList);
        restaurantList=restaurantList.Where(x => x.Tags == null ? false : x.Tags.Any(y => y.value == tag)); 
        return Ok(restaurantList);
    }

    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {

        var restaurants = _db.Restaurant.ToList().FirstOrDefault(x => x.id == id);
        restaurants.Avg = _db.Comments.Any() ? _db.Comments.Average(x => x.Rate) : 3.5;

        return Ok(restaurants);
    }
    [HttpGet("JustRestaurants")]
    public ActionResult<List<Restaurant>> GetJustRestaurantList()
    {
        var justRestaurantList = _db.Restaurant.ToList();
        foreach (var item in justRestaurantList)
        {
            item.Menu = null;
        }
        return justRestaurantList;
    }
    [HttpPost]
    public ActionResult<Restaurant> Post([FromBody] Restaurant value)
    {
        _db.Restaurant.Add(value);
        _db.SaveChangesAsync();
        return Ok(value);
    }


    [HttpGet("MakeFakeData")]
    public ActionResult MakeFakeData()
    {
        var c1 = new City
        {
            id = 1,
            CityName = "Zanjan",
        };
        var c2 = new City
        {
            id = 2,
            CityName = "Tehran"
        };
        var tag1 = new Tag
        {
            id = 1,
            value = "Chicken"
        };
        var tag2 = new Tag
        {
            id = 2,
            value = "cheap"
        };
        var r1 = new HttpRestaurant
        {

            Address = "right here 1",

            BackgroundImg = "",
            Description = "some restaurant1",
            LogoImg = "",
            Name = "KFC1"
        };
        var r1Norm = _mapper.Map<Restaurant>(r1);
        try
        {
            _db.Restaurant.Add(r1Norm);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok(new List<Restaurant> { r1Norm });
    }

}

