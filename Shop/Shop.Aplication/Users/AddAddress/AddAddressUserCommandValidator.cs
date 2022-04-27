using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Users.AddAddress
{
    public class AddAddressUserCommandValidator:AbstractValidator<AddAddressUserCommand>
    {
        public AddAddressUserCommandValidator()
        {
            RuleFor(r => r.City)
                .NotEmpty().WithMessage(ValidationMessages.required("شهر"));
            RuleFor(r => r.Shire)
                .NotEmpty().WithMessage(ValidationMessages.required("استان"));
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(r => r.Family)
                .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(r => r.PostalAddress)
                .NotEmpty().WithMessage(ValidationMessages.required("ادرس پستی"));
            RuleFor(r => r.PostalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
            RuleFor(r => r.NationalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalId();
        }
    }
}
