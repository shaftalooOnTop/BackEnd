using System.ComponentModel.DataAnnotations.Schema;
using Resturant_managment.Models.Base;

namespace Resturant_managment.Models;

public class Photo:BaseClass
{
    public string ImgName { get; set; }
    public IFormFile Image { get; set; }
}