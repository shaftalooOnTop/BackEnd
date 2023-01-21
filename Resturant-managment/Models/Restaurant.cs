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
    public virtual List<ThemeOfTable>?  ThemeOfTable { get; set; }
    public virtual List<Poll>? Polls { get; set; }
    public virtual List<primium>? Primiums { get; set; }
    public DateTime? primium_ex { get; set; }
    public  DateTime StartWorkingHour { get; set; }
    public DateTime EndWorkingHour { get; set; }
    public virtual List<RestaurantTable>? tables { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [ForeignKey("CityId")]
    public virtual City? City { get; set; }
    public virtual List<Employee>? Employees { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public double rate { get; set; }
    [NotMapped]
    public List<Food> Favorites { get; set; } = new List<Food>();
    [IgnoreDataMember]
    [JsonIgnore]
    [ForeignKey("InventoriesId")]
    public virtual List<Inventory>? Inventories { get; set; }
    public virtual int? InventoriesId { get; set; }
    //[ForeignKey("RestaurantIdentityId")]
    [JsonIgnore]
    [IgnoreDataMember]
    public virtual RestaurantIdentity? RestaurantIdentity { get; set; }
    public virtual string? RestaurantIdentityId { get; set; }

   //[ForeignKey("PrimiumId")]
    //public virtual primium? Primium { get; set; }
    //public virtual int? PrimiumtId { get; set; }

}