using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Aplication.Orders.DecreaseItemCount
{
    public class DecreaseItemCountOrderCommandHandler : IBaseCommandHandler<DecreaseItemCountOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public DecreaseItemCountOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DecreaseItemCountOrderCommand request, CancellationToken cancellationToken)
        {
            var currentorder =await _repository.GetUserCurrentOrder(request.UserId);
            if (currentorder == null)
                return OperationResult.NotFound();
            currentorder.DecreseitemCount(request.ItemId, request.Count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
