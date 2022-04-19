using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Categories.AddChild
{

    public partial class AddChildCategoryCommandHandler
    {
        public class AddChildCategoryValidator : AbstractValidator<AddChildCategoryCommand>
        {
            public AddChildCategoryValidator()
            {
                RuleFor(r => r.Title)
                    .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

                RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
            }
        }
    }
}
