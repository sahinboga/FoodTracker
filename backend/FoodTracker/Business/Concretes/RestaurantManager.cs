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
	public class RestaurantManager : IRestaurantService
	{
		public IResult Add(Restaurant restaurant)
		{
			throw new NotImplementedException();
		}

		public IResult Delete(Restaurant restaurant)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<Restaurant>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<Restaurant> GetById(int restaurantId)
		{
			throw new NotImplementedException();
		}

		public IResult Update(Restaurant restaurant)
		{
			throw new NotImplementedException();
		}
	}
}
