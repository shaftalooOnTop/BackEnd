﻿using Resturant_managment.Models.Base;

namespace Resturant_managment.Models
{
    public class LandingPage : BaseClass
    {
        public string? phonenumber { get; set; }
        public string? address { get; set; }
        public virtual Photo? photo { get; set; }
        public string title { get; set; }
        public  string? description { get; set; }


    }
}
