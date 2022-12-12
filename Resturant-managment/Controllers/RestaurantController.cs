using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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

    public RestaurantController(RmDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult<List<Restaurant>> Get(string tag, int size = 10, int number = 0, int cityid = -1)
    {

        var restaurantList = _db.Restaurant.ToList().Skip(size * number).Take(size);
        restaurantList.All(x => { x.Comments = null; return true; });
        if (tag != "all")
            restaurantList = restaurantList.Where(x => x.Tags == null ? false : x.Tags.Any(y => y.value == tag)).ToList();
        if (cityid == -1)
            restaurantList = restaurantList.Where(c => cityid == cityid).ToList();
        return Ok(restaurantList);
    }



    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {

        var restaurants = _db.Restaurant.FirstOrDefault(x => x.id == id);
        if (restaurants == null) return NotFound();
        restaurants.Avg = _db.Comments.Where(x => x.RestaurantId == id).Any() ? _db.Comments.Where(x => x.RestaurantId == id).Average(x => x.Rate) : 3.5;
        var result = _db.Foods.Where(x => x.Category.RestaurantId == id);

        var t = _db.Orders.Where(r => r.restaurantId == id)
            .SelectMany((arg) => arg.Foods).ToList()
            .GroupBy(x => x.id)
            .ToDictionary(x => x.Key, x => x.Count());

        //t.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        var ls = new List<KeyValuePair<Food, int>>();
        result
            .ToList();
        foreach (var i in result)
        {
            if (!t.ContainsKey(i.id)) continue;
            var tmp = new KeyValuePair<Food, int>(i, t[i.id]);
            ls.Add(tmp);
        }
        ls.Sort((x, y) => x.Value - y.Value);
        restaurants.Favorites = ls.Select(x => x.Key).Take(5).ToList();
        return Ok(restaurants);
    }

    [HttpPost]
    public ActionResult<Restaurant> Post([FromBody] Restaurant value)
    {
        _db.Restaurant.Add(value);
        _db.SaveChanges();
        return Ok(value);
    }
    [HttpGet("GetRestaurantMenu/{id}")]
    public ActionResult<List<Category>> GetRestaurantMenu(int id)
    {
        return _db.Categories.Where(c => c.RestaurantId == id).ToList();
    }
    [HttpPut]
    public ActionResult<Restaurant> Put(Restaurant restaurant)
    {
        _db.Update(restaurant);
        _db.SaveChanges();
        return restaurant;
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var obj = _db.Restaurant.Find(id);
        if (obj == null) return NotFound();
        _db.Remove(obj);
        return Ok(id);
    }


    [HttpGet("fake")]
    public ActionResult getFake()
    {
        var img = _db.Foods.FirstOrDefault().Image;
        if (img == "" || img == null) return NotFound();
        var type = "";
        if (img.StartsWith("data:image/jpeg;base64,")) type = ("image/jpeg");
        if (img.StartsWith("data:image/png;base64,")) type = "image/ong";


        //res.Value=img;
        //var o = new OkObjectResult(img);
        return Content(img, type);
    }
  
}

