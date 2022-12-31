using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
    public class LandingPage : BaseClass
    {
        public string? phonenumber { get; set; }
        public string? address { get; set; }
        public virtual List<Photo>? photo { get; set; }
        public  string? description { get; set; }


    }
}
