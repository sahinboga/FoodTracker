using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers.FileHelpers
{
	public static class ImageFileHelper
	{
        private static string restaurantImageFolderName = "Images/";
        private static string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", restaurantImageFolderName);
        private static string defaultRestaurantImage = "defaultRestaurant.png";
        public static string Upload(IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                string fileName = Path.GetFileName(formFile.FileName);
                string guid = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(fileName);
                string newFileName = guid + fileExtension;
                string filePath = root + $@"\{newFileName}";

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return "/" + restaurantImageFolderName + newFileName;
                //return filePath;
            }
            return "";
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }


        public static string GetDefaultRestaurantImagePath()
        {
            return "/" + restaurantImageFolderName + defaultRestaurantImage;
        }
    }
}
