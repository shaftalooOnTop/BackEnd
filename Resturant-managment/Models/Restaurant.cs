using System.ComponentModel.DataAnnotations.Schema;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Restaurant:BaseClass
{
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual List<Menu>? Menus { get; set; }
    public virtual List<Order>? Orders { get;set; }
    // [ForeignKey("RestaurantId")]
    public virtual ICollection<Tag> Tags { get;set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string BackgroundImg { get; set; }
    public virtual City? City { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}