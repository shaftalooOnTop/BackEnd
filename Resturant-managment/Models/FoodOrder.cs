using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
    public class FoodOrder : BaseClass
    {
        public int FoodId { get; set; }
        public Food food { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }


    }
}
