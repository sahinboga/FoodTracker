using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
	public interface ICategoryService
	{
		IDataResult<List<Category>> GetAll();
		IResult Add(Category category);
		IDataResult<Category> GetById(int categoryId);
		IResult Update(Category category);
		IResult Delete(Category category);
	}
}
