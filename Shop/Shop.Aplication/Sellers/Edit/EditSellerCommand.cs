using Common.Application;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Sellers.Edit
{
    public class EditSellerCommand:IBaseCommand
    {
        public EditSellerCommand(long userId, string shopName, string nationalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
    }
    internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainservice;

        public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller =await _repository.GetTracking(request.UserId);
            if (seller == null)
                return OperationResult.NotFound();
            seller.Edit(request.ShopName, request.NationalCode, _domainservice);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
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
