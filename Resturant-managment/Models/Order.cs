using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Order:BaseClass
{
    public virtual List<Food> Foods { get; set; }
    public int Restaurantid { get; set; }
}