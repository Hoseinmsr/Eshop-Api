using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Aplication.Sellers.EditInventory
{
    internal class EditInventoryCommandHandler : IBaseCommandHandler<EditInventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public EditInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
        {
            var Seller =await _repository.GetTracking(request.SellerId);
            if (Seller == null)
                return OperationResult.NotFound();
            Seller.EditInventory(request.InventoryId, request.Count, request.Price, request.PercentageDiscount);
            Seller.ChangeStatus(request.Status);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
