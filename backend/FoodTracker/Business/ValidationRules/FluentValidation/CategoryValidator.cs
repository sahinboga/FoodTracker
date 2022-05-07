using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	class CategoryValidator:AbstractValidator<Category>
	{
		public CategoryValidator()
		{

		}
	}
}
