using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
	public interface IRestaurantImageService
	{
		IDataResult<List<RestaurantImage>> GetAll();
		IResult Add(RestaurantImage restaurantImage);
		IDataResult<RestaurantImage> GetById(int imageId);
		IResult Update(RestaurantImage restaurantImage);
		IResult Delete(RestaurantImage restaurantImage);
	}
}
