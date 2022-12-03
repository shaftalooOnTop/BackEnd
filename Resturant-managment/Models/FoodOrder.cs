using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class FoodOrder : BaseClass
    {
        public int FoodId { get; set; }
     
        public virtual Food? food { get; set; } = null;
        public int OrderId { get; set; }
       
        public  virtual Order? order { get; set; } = null;
    }
}
