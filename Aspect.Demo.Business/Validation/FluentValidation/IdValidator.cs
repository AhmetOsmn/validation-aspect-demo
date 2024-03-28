using FluentValidation;

namespace Aspect.Demo.Business.Validation.FluentValidation
{
    public class IdValidator: AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(x => x)
                .GreaterThan(0).WithMessage("ID değeri 0'dan büyük olmalıdır.");
        }
    }
}
