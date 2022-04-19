using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Categories.Edit
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }

}
