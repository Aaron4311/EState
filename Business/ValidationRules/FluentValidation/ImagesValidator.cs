using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class ImagesValidator : AbstractValidator<Image>
	{
        public ImagesValidator()
        {
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Image name cannot be left empty");
			RuleFor(x => x.AdvertId).NotEmpty().WithMessage("Advert area cannot be left empty");

		}
	}
}
