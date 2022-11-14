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

        public RestaurantController(RmDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
            
         
        var r = _db.Restaurant.Include("Tags").Where(x=>x.id==id);
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
                    Name = i.Name,
                    Menus = i.Menus,
                    Orders = null
                };
                result.Append(card);

            }

            return result;
        }
[HttpGet("MakeFakeData")]
        public ActionResult MakeFakeData()
        {
            var c1 = new City
            {
                id =1,
                CityName = "Zanjan",
            };
            var c2 = new City
            {
                id=2,
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
            var r1Norm=_mapper.Map<Restaurant>(r1);
            try
            {
                _db.Restaurant.Add(r1Norm);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return  Ok(new List<Restaurant> { r1Norm });
        }

    }

