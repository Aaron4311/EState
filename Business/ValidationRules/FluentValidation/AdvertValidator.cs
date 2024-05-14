using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class AdvertValidator : AbstractValidator<Advert>
	{
        public AdvertValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be left empty");
			RuleFor(x => x.AdvertTitle).NotEmpty().WithMessage("Title cannot be left empty");
			RuleFor(x => x.AdvertTitle).MinimumLength(30).MaximumLength(500).WithMessage("Please enter a title between minimum 30 character and maximum 500 character");
			RuleFor(x => x.Area).NotEmpty().WithMessage("Area cannot be left empty");
			RuleFor(x => x.NumberOfBathrooms).NotEmpty().WithMessage("Bathroom number must be entered");
			RuleFor(x => x.NumberOfRooms).NotEmpty().WithMessage("Room number must be entered");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Floor area cannot be left empty");
			RuleFor(x => x.Garage).NotEmpty().WithMessage("Garage area cannot be left empty");
			RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be left empty");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number cannot be left empty");
			RuleFor(x => x.NeighbourhoodId).NotEmpty().WithMessage("Neighbourhood cannot be left empty");
			RuleFor(x => x.DistrictId).NotEmpty().WithMessage("District cannot be left empty");
			RuleFor(x => x.TypeId).NotEmpty().WithMessage("Type cannot be left empty");
			RuleFor(x => x.CityId).NotEmpty().WithMessage("City cannot be left empty");
			RuleFor(x => x.SituationId).NotEmpty().WithMessage("Situation area cannot be left empty");



		}

	}
}
