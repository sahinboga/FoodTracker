using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public static class Messages
	{
		public static string Listed = "Listelendi";

		public static string RestaurantAdded = "Restoran eklendi";
		public static string RestaurantListed = "Restoran listelendi";
		public static string RestaurantUpdated = "Restoran güncellendi";
		public static string RestaurantDeleted = "Restoran silindi";
		public static string RestaurantNameAlreadyExists="Aynı isimde başka restoran zaten bulunmaktadır";

		public static string ImageAdded="Resim Eklendi";
		public static string ImageDeleted="Resim Silindi";
		public static string ImageUpdated="Resim Güncellendi";
		public static string ImageLimitExceded= "En fazla 3 adet Fotoğraf koyabilirsiniz.";
	}
}
