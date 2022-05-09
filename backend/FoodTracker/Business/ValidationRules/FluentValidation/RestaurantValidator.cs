using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class RestaurantValidator:AbstractValidator<Restaurant>
	{
		public RestaurantValidator() {

			RuleFor(rest => rest.RestaurantName).NotEmpty();
			RuleFor(rest => rest.RestaurantName).MinimumLength(5);
			//RuleFor(rest => rest.CategoryId).NotEmpty();
			//RuleFor(rest => rest.CountyId).NotEmpty();
			RuleFor(rest => rest.FoundedDate).NotEmpty();
		}
	}
}
