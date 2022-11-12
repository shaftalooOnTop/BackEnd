using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_managment.Models;
using Resturant_managment.Repositories;

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
        public ActionResult<List<Restaurant>> Get()
        {
            var restaurantList = _db.Restaurant.ToList();
            return Ok(restaurantList);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            
            var rep = new MenuRepository(_db);
        var r = _db.Restaurant.Where(x=>x.id==id);
            return Ok(r);
        }
        [HttpGet("JustRestaurants")]
        public ActionResult<List<Restaurant>> GetJustRestaurantList()
        {
             var justRestaurantList = _db.Restaurant.ToList();
             foreach (var item in justRestaurantList)
             {
                 item.Menus = null;
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

        [HttpGet("GetRestaurantsCardData")]
        public IEnumerable<RestaurantCard> GetRestaurantsCardData()
        {
            var restaurants = _db.Restaurant.ToList();
            var result = new List<RestaurantCard>();
            foreach (var i in restaurants)
            {
                var avg = _db.Comments.Average(x => x.Rate);

                var card = new RestaurantCard
                {
                    Avg = avg,
                    Address = i.Address,
                    id = i.id,
                    name = i.name,
                    Menus = null,
                    Orders = null
                };
                result.Append(card);

            }

            return result;
        }


    }

