using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Concretes
{
	public class RestaurantManager : IRestaurantService
	{
		IRestaurantDal _restaurantDal;

		public RestaurantManager(IRestaurantDal restaurantDal)
		{
			_restaurantDal = restaurantDal;
		}

		public IResult Add(Restaurant restaurant)
		{
			_restaurantDal.Add(restaurant);
			return new SuccessResult(Messages.RestaurantAdded);
		}

		public IResult Delete(Restaurant restaurant)
		{
			_restaurantDal.Delete(restaurant);
			return new SuccessResult(Messages.RestaurantDeleted);
		}

		public IDataResult<List<Restaurant>> GetAll()
		{
			return new SuccessDataResult<List<Restaurant>>(_restaurantDal.GetAll(),Messages.RestaurantListed);
		}

		public IDataResult<Restaurant> GetById(int restaurantId)
		{
			var restaurant=_restaurantDal.GetById(r=>r.Id==restaurantId);
			return new SuccessDataResult<Restaurant>(restaurant);
		}

		public IResult Update(Restaurant restaurant)
		{
			_restaurantDal.Update(restaurant);
			return new SuccessResult(Messages.RestaurantUpdated);
		}
	}
}
