using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
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
    public List<string> RoleName { get; set; }

    public int? RestaurantId { get; set; }
    [JsonIgnore]
    [IgnoreDataMember]
    [ForeignKey("RestaurantId")]
    public virtual  Restaurant? Restaurant { get; set; }


}
