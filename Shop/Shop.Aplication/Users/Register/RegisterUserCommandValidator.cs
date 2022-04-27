using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Users.Register
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.Password)
              .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
              .NotNull()
              .MinimumLength(4).WithMessage("باید بیش تر از 4 کاراکتر باشد");
        }
    }
}
