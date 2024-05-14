using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class NeighbourhoodValidator : AbstractValidator<Neighbourhood>
	{
        public NeighbourhoodValidator()
        {
            RuleFor(x => x.NeighbourhoodName).NotEmpty().WithMessage("Neighbourhood name cannot be left empty");
			RuleFor(x => x.DistrictId).NotEmpty().WithMessage("District cannot be left empty");

		}
	}
}
