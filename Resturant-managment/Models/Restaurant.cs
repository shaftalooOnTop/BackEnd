using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Restaurant:BaseClass
{
    public string name { get; set; }
    public string Address { get; set; }
    public List<Menu>? Menus { get; set; }
    public List<Order>? Orders { get;set; }
    public string Description { get; set; }
}