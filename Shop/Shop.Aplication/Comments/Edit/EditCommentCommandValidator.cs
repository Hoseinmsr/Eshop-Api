using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Comments.Edit
{
    public class EditCommentCommandValidator:AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
        }
    }
}
