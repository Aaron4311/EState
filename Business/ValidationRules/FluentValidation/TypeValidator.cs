using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class TypeValidator : AbstractValidator<Entity.Concrete.Type>
	{
        public TypeValidator()
        {
            RuleFor(x => x.TypeName).NotEmpty().WithMessage("Type name cannot be left empty");

        }
    }
}
