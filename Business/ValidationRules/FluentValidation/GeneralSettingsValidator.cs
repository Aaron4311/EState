using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class GeneralSettingsValidator : AbstractValidator<GeneralSettings>
	{
        public GeneralSettingsValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be left empty");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be left empty");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number cannot be left empty");
			RuleFor(x => x.ImageName).NotEmpty().WithMessage("Image name cannot be left empty");

		}
	}
}
