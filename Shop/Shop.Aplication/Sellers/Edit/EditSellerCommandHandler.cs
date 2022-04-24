using Common.Application;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Aplication.Sellers.Edit
{
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
}
