using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class DistrictValidator : AbstractValidator<District>
	{
        public DistrictValidator()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("Name cannot be left empty");
			RuleFor(x => x.CityId).NotEmpty().WithMessage("City cannot be left empty");

		}
	}
}
