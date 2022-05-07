using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Concretes
{
	public class CityManager : ICityService
	{
		ICityDal _cityDal;

		public CityManager(ICityDal cityDal)
		{
			_cityDal = cityDal;
		}

		public IDataResult<List<City>> GetAll()
		{
			return new SuccessDataResult<List<City>>(_cityDal.GetAll(),Messages.Listed);
		}

		public IDataResult<City> GetById(int cityId)
		{
			var city = _cityDal.GetById(c => c.Id == cityId);
			return new SuccessDataResult<City>(city);
		}
	}
}
