using System;
namespace Resturant_managment.Models
{
	public class FoodSell
	{
        public Food Food { get; set; }
        public int SellNubmer { get; set; }


    }
    public class DayFoodSell
    {
        public DateTime Day { get; set; }
        public List<FoodSell> SellList { get; set; } = new ();
    }
}

