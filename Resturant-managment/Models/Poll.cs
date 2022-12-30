using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class Poll:BaseClass
    {
       
        public int score1 { get; set; }
        public int score2 { get; set; }
        public int score3 { get; set; }
        public int score4 { get; set; }
        public int score5 { get; set; }
        public int score6 { get; set; }
        public int score7 { get; set; }
       

        public int restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant Restaurant { get; set; }


    }
}
