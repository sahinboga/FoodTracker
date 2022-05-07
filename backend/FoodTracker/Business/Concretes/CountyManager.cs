using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
	public class CountyManager : ICountyService
	{
		ICountyDal _countyDal;

		public CountyManager(ICountyDal countyDal)
		{
			_countyDal = countyDal;
		}

		public IDataResult<List<County>> GetAll()
		{
			return new SuccessDataResult<List<County>>(_countyDal.GetAll(),Messages.Listed);
		}

		public IDataResult<County> GetById(int countyId)
		{
			var county = _countyDal.GetById(c => c.Id == countyId);
			return new SuccessDataResult<County>(county);
		}

		public IDataResult<List<County>> GetCountyByCity(int cityId)
		{
			var county=_countyDal.GetAll(c=>c.CityId==cityId);
			return new SuccessDataResult<List<County>>(county);
		}
	}
}
