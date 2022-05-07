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
	public class CategoryManager : ICategoryService
	{
		public IResult Add(Category category)
		{
			throw new NotImplementedException();
		}

		public IResult Delete(Category category)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<Category>> GetAll()
		{
			throw new NotImplementedException();
		}

		public IDataResult<Category> GetById(int categoryId)
		{
			throw new NotImplementedException();
		}

		public IResult Update(Category category)
		{
			throw new NotImplementedException();
		}
	}
}
