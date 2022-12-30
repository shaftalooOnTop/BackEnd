using Resturant_managment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_managment.Models
{
    public class Poll:BaseClass
    {
        public string description = "please rate this fild whith number 1 to 5 in order :very bad , bad, medium , good or very good, 1 means very bad and goes on ";
        public string title1 = "service quality";
        public int score1 { get; set; }
        public string title2 = "food quality";
        public int score2 { get; set; }
        public string title3 = "Personnel Behavior";
        public int score3 { get; set; }
        public string title4 = "How long have you waited until you could find an empty table (Don't answer if you had already booked)  from very much to very quickly";
        public int score4 { get; set; }
        public string title5 = "restaurant atmosphere";
        public int score5 { get; set; }
        public string title6 = "find room in parking lot";
        public int score6 { get; set; }
        public string title7 = "cleanliness of restaurant";
        public int score7 { get; set; }
        public string? recommendation { get; set; }

        public int restaurantid { get; set; }
        [ForeignKey("restaurantid")]
        public virtual Restaurant Restaurant { get; set; }


    }
}
