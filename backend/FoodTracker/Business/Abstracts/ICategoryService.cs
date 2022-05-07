using Core.Utilities.Results;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Abstracts
{
	public interface ICategoryService
	{
		IDataResult<List<Category>> GetAll();
		IDataResult<Category> GetById(int categoryId);
	}
}
