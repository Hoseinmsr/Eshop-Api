using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Orders.CheckOut
{
    public class CheckOutOrderCommandValidator:AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));
            RuleFor(r => r.Family)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(r => r.City)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("شهر"));
            RuleFor(r => r.Shire)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("استان"));
            RuleFor(r => r.Phonenumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("شماره موبایل"))
                .MaximumLength(11).WithMessage("نا معتبر است")
                .MinimumLength(11).WithMessage("نا معتبر است");
            RuleFor(r => r.NationalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("کد ملی"))
                .MaximumLength(10).WithMessage("نا معتبر است")
                .MinimumLength(10).WithMessage("نا معتبر است")
                .ValidNationalId();
            RuleFor(r => r.PostalAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("ادرس"));
            RuleFor(r => r.PostalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("کد پستی"));
                
        }
    }
}
