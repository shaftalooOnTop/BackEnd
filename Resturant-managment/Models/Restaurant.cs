using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Restaurant:BaseClass
{
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual List<Category>? Menu { get; set; }
    public virtual List<Order>? Orders { get;set; }
    public virtual List<Tag>? Tags { get;set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string BackgroundImg { get; set; }
    public virtual int? CityId { get; set; }
    
    public  DateTime StartWorkingHour { get; set; }
    public DateTime EndWorkingHour { get; set; }
    public virtual List<RestaurantTable>? tables { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("CityId")]
    public virtual City? City { get; set; }
    
    public virtual ICollection<Comment>? Comments { get; set; }
    public double Avg { get; set; }



}