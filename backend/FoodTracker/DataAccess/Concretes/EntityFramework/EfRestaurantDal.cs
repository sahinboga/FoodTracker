using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concretes.EntityFramework
{
	public class EfRestaurantDal : EfEntityRepositoryBase<Restaurant, FoodTrackerContext>, IRestaurantDal
	{
		public List<RestaurantDto> GetAllWithDetails(Expression<Func<RestaurantDto, bool>> filter = null)
		{
			using (FoodTrackerContext context = new FoodTrackerContext())
			{
				var result = from r in context.Restaurants
							 join c in context.Categories on r.CategoryId equals c.Id
							 join co in context.Counties on r.CountyId equals co.Id
							 join city in context.Cities on co.CityId equals city.Id
							 select new RestaurantDto
							 {
								 Id = r.Id,
								 RestaurantName = r.RestaurantName,
								 Category = c.CategoryName,
								 Location = city.CityName + "/" + co.CountyName,
								 FoundedDate = r.FoundedDate
							 };
				return filter == null ? result.ToList() : result.Where(filter).ToList();
			}
		}
	}
}
