using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstracts
{
	public interface IRestaurantImageService
	{
		IDataResult<List<RestaurantImage>> GetAll();
		IResult Add(RestaurantImage restaurantImage);
		IDataResult<RestaurantImage> GetById(int imageId);
		IResult Update(RestaurantImage restaurantImage);
		IResult Delete(RestaurantImage restaurantImage);

		IResult UploadRestaurantImage(IFormFile imageFile, RestaurantImage restaurantImage);

		IDataResult<List<RestaurantImage>> GetRestaurantImagesByRestaurantId(int restaurantId);
		IDataResult<RestaurantImage> GetFirstOrDefaultByCarId(int restaurantId);
	}
}
