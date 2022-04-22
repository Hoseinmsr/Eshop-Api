using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Products.AddImage
{
    public class AddImageProductCommandValidator:AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }
}
