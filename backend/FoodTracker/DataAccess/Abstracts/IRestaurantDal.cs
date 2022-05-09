using Core.DataAccess;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstracts
{
	public interface IRestaurantDal:IEntityRepository<Restaurant>
	{
		//List<RestaurantDto> GetAllWithDetails(Expression<Func<RestaurantDto, bool>> filter = null);
	}
}
