using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
	public class RestaurantImageManager : IRestaurantImageService
	{
		public IResult Add(RestaurantImage restaurantImage)
		{
			throw new NotImplementedException();
		}

		public IResult Delete(RestaurantImage restaurantImage)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<RestaurantImage>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<RestaurantImage> GetById(int imageId)
		{
			throw new NotImplementedException();
		}

		public IResult Update(RestaurantImage restaurantImage)
		{
			throw new NotImplementedException();
		}
	}
}
