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
	public class CityManager : ICityService
	{
		public IDataResult<List<City>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<City> GetById(int cityId)
		{
			throw new NotImplementedException();
		}
	}
}
