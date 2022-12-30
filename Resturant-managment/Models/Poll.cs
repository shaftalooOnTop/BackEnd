using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class Poll:BaseClass
    {
       
        public double score1 { get; set; }
        public double score2 { get; set; }
        public double score3 { get; set; }
        public double score4 { get; set; }
        public double score5 { get; set; }
        public double score6 { get; set; }
        public double score7 { get; set; }
       

        public int restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant? Restaurant { get; set; }


    }
}
