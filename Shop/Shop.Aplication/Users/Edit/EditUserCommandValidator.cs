using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Users.Edit
{
    public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.Phonenumber)
               .ValidPhoneNumber();
            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نا معتبراست");
            RuleFor(r => r.Password)
                .MinimumLength(4).WithMessage("باید بیش تر از 4 کاراکتر باشد");
            RuleFor(r => r.Avatar)
                .JustImageFile();
        }
    }
}
