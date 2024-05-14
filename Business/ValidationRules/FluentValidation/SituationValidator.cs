using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class SituationValidator : AbstractValidator<Situation>
	{
        public SituationValidator()
        {
            RuleFor(x => x.SituationName).NotEmpty().WithMessage("Situation name cannot be left empty");

        }
    }
}
