﻿using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.Sellers.Edit
{
    public class EditSellerCommandValidator:AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
              .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));
            RuleFor(r => r.NationalCode)
                .ValidNationalId()
                .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"));
        }
    }
}
