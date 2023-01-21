namespace Resturant_managment.Models
{
    public class UserSignUp
    {
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }

        public string? city { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        
    }
}
