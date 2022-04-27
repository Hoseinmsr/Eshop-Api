using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Users.Create
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.Phonenumber)
                .ValidPhoneNumber();
            RuleFor(r => r.Email)
                .EmailAddress();
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull()
                .MinimumLength(4).WithMessage("باید بیش تر از 4 کاراکتر باشد");
        }
    }
}
