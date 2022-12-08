using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Resturant_managment.Utils
{
	public class Utils
	{
		private readonly RmDbContext _db;
		public Utils(RmDbContext db)
        {
			_db = db;
        }
		public  void Base64Save(string img)
			{
				byte[] bytes = Convert.FromBase64String(img);
				Image image;
				using(var mem=new MemoryStream(bytes))
				{
					image = Image.FromStream(mem);
				}
				var newFileName=_db.Photos.Last().id+1;
			var type = "";
			ImageFormat encoder=ImageFormat.Png ;
			if (img.StartsWith("data:image/jpeg;base64,")) {
				type = ("image/jpeg");
				encoder = ImageFormat.Jpeg;
					}
			if (img.StartsWith("data:image/png;base64,")) { type = "image/png"; encoder = ImageFormat.Png; }

			image.Save("wwwroot/img_"+type, encoder);
			}
	}
}

