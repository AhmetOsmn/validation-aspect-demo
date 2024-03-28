using FluentValidation;
using Aspect.Demo.Business.DTOs;

namespace Aspect.Demo.Business.Validation.FluentValidation.Product
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz")
                .Length(2, 150).WithMessage("Ürün adı 2 ile 150 karakter arasında olmalıdır");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz")
                .Length(5, 500).WithMessage("Açıklama 5 ile 500 karakter arasında olmalıdır");
        }
    }
}
