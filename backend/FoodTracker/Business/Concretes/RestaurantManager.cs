using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concretes
{
	public class RestaurantManager : IRestaurantService
	{
		IRestaurantDal _restaurantDal;

		public RestaurantManager(IRestaurantDal restaurantDal)
		{
			_restaurantDal = restaurantDal;
		}

		[ValidationAspect(typeof(RestaurantValidator))]
		public IResult Add(Restaurant restaurant)
		{
			//Aynı isimde restoran eklenmez
			IResult result = BusinessRules.Run(CheckIfRestaurantNameExists(restaurant.RestaurantName));

			if (result != null)
			{
				return result;
			}

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

		public IDataResult<List<RestaurantDto>> GetAllByCategory(string category)
		{
			var restorant = _restaurantDal.GetAllWithDetails(r => r.Category == category);
			return new SuccessDataResult<List<RestaurantDto>>(restorant);
		}

		public IDataResult<List<Restaurant>> GetAllByCategoryId(int categoryId)
		{
			var restorant = _restaurantDal.GetAll(r => r.CategoryId == categoryId);
			return new SuccessDataResult<List<Restaurant>>(restorant);
		}

		public IDataResult<List<RestaurantDto>> GetAllWithDetails()
		{
			return new SuccessDataResult<List<RestaurantDto>>(_restaurantDal.GetAllWithDetails(), Messages.RestaurantListed);
		}

		public IDataResult<Restaurant> GetById(int restaurantId)
		{
			var restaurant=_restaurantDal.GetById(r=>r.Id==restaurantId);
			return new SuccessDataResult<Restaurant>(restaurant);
		}

		public IDataResult<RestaurantDto> GetDetailById(int restaurantId)
		{
			var restaurant = _restaurantDal.GetAllWithDetails(r => r.Id==restaurantId).FirstOrDefault();
			return new SuccessDataResult<RestaurantDto>(restaurant);
		}

		[ValidationAspect(typeof(RestaurantValidator))]
		public IResult Update(Restaurant restaurant)
		{
			//aynı isimde restoran güncellemesi olamaz
			IResult result = BusinessRules.Run(CheckIfRestaurantNameExists(restaurant.RestaurantName));

			if (result != null)
			{
				return result;
			}
			
			_restaurantDal.Update(restaurant);
			return new SuccessResult(Messages.RestaurantUpdated);
			
		}

		// aynı isimde restoranların önüne geçme kuralı
		private IResult CheckIfRestaurantNameExists(string restaurantName)
		{
			var result = _restaurantDal.GetAll(r => r.RestaurantName == restaurantName).Any();
			if (result)
			{
				return new ErrorResult(Messages.RestaurantNameAlreadyExists);
			}
			return new SuccessResult();
		}
	}
}
