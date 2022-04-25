using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.SiteEntities.Banners.Create
{
    public class CreateBannerCommandValidator:AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
             .NotNull().WithMessage(ValidationMessages.required("عکس"))
             .JustImageFile();
            RuleFor(r => r.Link)
                .NotNull().WithMessage(ValidationMessages.required("لینک"))
                .NotEmpty();
        }
    }
}
