using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(r => r.Link)
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"))
                .NotNull();
            RuleFor(r => r.ImageFile)
                .NotEmpty().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"))
                .NotNull();
        }
    }
}
