﻿using Core.Utilities.Results;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Abstracts
{
	public interface IRestaurantService
	{
		IDataResult<List<Restaurant>> GetAll();
		IResult Add(Restaurant restaurant);
		IDataResult<Restaurant> GetById(int restaurantId);
		IResult Update(Restaurant restaurant);
		IResult Delete(Restaurant restaurant);
	}
}