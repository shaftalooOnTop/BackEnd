using AutoMapper;
using Resturant_managment.Models.HTTPModels;

namespace Resturant_managment.Models.AutoMapper;

public class Profiles:Profile
{
    public Profiles()
    {
        CreateMap<Restaurant, HttpRestaurant>().ReverseMap();
    }
}