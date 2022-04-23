﻿using Common.Application.Validation;
using FluentValidation;

namespace Shop.Aplication.Roles.Edit
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.Title)
               .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }

}