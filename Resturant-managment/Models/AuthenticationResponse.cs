namespace Resturant_managment.Models;

public class AuthenticationResponse
{
    private DateTime expiration;
    public string Token { get; set; }

    public DateTime Expiration
    {
        get
        {
            return expiration;
        }
        set
        {
            expiration=value.ToLocalTime();
        }
    }
}