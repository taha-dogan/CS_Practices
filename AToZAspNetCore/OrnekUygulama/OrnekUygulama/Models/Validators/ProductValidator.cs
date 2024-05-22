using FluentValidation;

namespace OrnekUygulama.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.DeveloperEmail).NotNull().WithMessage("Email boş olamaz!");
            RuleFor(x => x.DeveloperEmail).EmailAddress().WithMessage("Lütfen geçerli bir mail sağlayın!");

            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Lütfen Product Name'i boş geçmeyin!");
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("Lütfen Product Name için en fazla 100 karakter girin!");
        }
    }
}
