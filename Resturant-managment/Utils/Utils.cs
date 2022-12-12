using System.Drawing;
using System.Drawing.Imaging;
using Resturant_managment.Models;

namespace Resturant_managment
{
	public class Utils
	{
		private readonly RmDbContext _db;
		public Utils(RmDbContext db)
        {
			_db = db;
        }
		public Photo Base64Save(string img)
		{
			var type = "";
			if (img.StartsWith("data:image/jpeg;base64,")) { type = "jpeg";
				img = img.Replace("data:image/jpeg;base64,","");
			}
			if (img.StartsWith("data:image/png;base64,")) {type = "png";
				img = img.Replace("data:image/png;base64,", "");

			}
			var guid = _db.PhotoTable.OrderBy(x=>x.id).Last().id + 1;
			var p = new Photo { ImgName= $"{guid}.{type}" };
				
			string filePath = $"wwwroot/{guid}.{type}";
			File.WriteAllBytes(filePath, Convert.FromBase64String(img));
			_db.Add(p);
			_db.SaveChanges();
			return p;
			}
	}
}

