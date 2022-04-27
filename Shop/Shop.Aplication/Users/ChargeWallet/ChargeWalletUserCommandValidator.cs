using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Users.ChargeWallet
{
    public class ChargeWalletUserCommandValidator : AbstractValidator<ChargeWalletUserCommand>
    {
        public ChargeWalletUserCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));
            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1000);
        }
    }
}
