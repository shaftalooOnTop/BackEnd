using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
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
        [IgnoreDataMember]
        public virtual Restaurant? Restaurant { get; set; }
        public virtual List<ReserveTable> ReserveTables { get; set; }

        

    }
}
