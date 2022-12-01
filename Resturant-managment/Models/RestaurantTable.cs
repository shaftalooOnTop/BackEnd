using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant_managment.Models
{
    public class RestaurantTable: BaseClass
    {
        public  int number { get; set; }
        public int capacity { get; set; } 
        
       

        public int RestaurantId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("RestaurantId")]

        public virtual Restaurant? Restaurant { get; set; }


        

    }
}
