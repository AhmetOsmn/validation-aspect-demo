using FluentValidation;
using ValidationAspect.Demo.Business.DTOs;

namespace ValidationAspect.Demo.Business.Validation.FluentValidation.Product
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0).WithMessage("Ürün ID'si 0'dan büyük olmalıdır.");

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
