using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Photo :BaseClass
{
    public string Img { get; set; }
    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Food Food { get; set; }
}