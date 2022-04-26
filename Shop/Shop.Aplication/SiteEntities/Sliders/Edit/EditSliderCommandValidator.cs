﻿using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Aplication.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandValidator:AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(r => r.ImageFile)
               .JustImageFile();
            RuleFor(r => r.Link)
                .NotNull().WithMessage(ValidationMessages.required("لینک"))
                .NotEmpty();
        }
    }
}
