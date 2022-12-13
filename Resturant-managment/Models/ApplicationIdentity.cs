using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class RestaurantIdentity : IdentityUser
{
    public string FullName { get; set; }


    public string Picture { get; set; }
    public virtual int CityId { get; set; }
    [ForeignKey("CityId")]
    public virtual City? city { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; }

    public virtual List<Payment>? Payments { get; set; }

    public virtual List<ReserveTable>? restable { get; set; }
    
    [NotMapped]
    public List<String> RoleName { get; set; }

}
public enum jobtype
{   
    fulltime, parttime
}
public class Employee :BaseClass
{
    public int earning { get; set; }
    public DateTime start { get; set; }
    public jobtype? jobtype { get; set; }
    public string position { get; set; }
    public virtual List<EntranceMangment>? entranceMangments { get; set; }
    public int restaurantid { get; set; }
    [ForeignKey("restaurantid")]
    public virtual Restaurant? Restaurant { get; set; }

    
    public string? identityid { get; set; }
    [ForeignKey("identityid")]
    public virtual RestaurantIdentity? RestaurantIdentity { get; set; }
}