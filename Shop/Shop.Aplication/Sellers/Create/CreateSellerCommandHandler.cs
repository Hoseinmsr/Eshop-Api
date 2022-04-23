using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Aplication.Sellers.Create
{
    internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainservice;
        public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId,request.ShopName,request.NationalCode,_domainservice);
            _repository.Add(seller);
           await _repository.Save();
            return OperationResult.Success();
        }
    }
}
