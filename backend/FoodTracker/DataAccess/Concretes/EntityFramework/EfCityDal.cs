using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
	public class EfCityDal: EfEntityRepositoryBase<City, FoodTrackerContext>, ICityDal
	{
	}
}
