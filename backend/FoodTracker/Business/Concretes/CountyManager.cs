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
	public class CountyManager : ICountyService
	{
		public IDataResult<List<County>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<County> GetById(int countyId)
		{
			throw new NotImplementedException();
		}
	}
}
