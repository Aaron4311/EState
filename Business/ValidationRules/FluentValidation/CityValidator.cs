using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CityValidator : AbstractValidator<City>
	{
        public CityValidator()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("City name cannot be left empty");
			RuleFor(x => x.CityName).MinimumLength(5).MaximumLength(25).WithMessage("Please enter a city name between minimum 5 character and maximum 25 character");
		

		}
	}
}
