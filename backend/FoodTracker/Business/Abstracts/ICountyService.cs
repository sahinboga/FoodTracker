using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
	public interface ICountyService
	{
		IDataResult<List<County>> GetAll();
		IDataResult<County> GetById(int countyId);
	}
}
