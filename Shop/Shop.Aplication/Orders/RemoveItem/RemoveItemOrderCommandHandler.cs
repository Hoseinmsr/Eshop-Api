using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Aplication.Orders.RemoveItem
{
    public class RemoveItemOrderCommandHandler : IBaseCommandHandler<RemoveItemOrderCommand>
    {
        IOrderRepository _repository;

        public RemoveItemOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveItemOrderCommand request, CancellationToken cancellationToken)
        {
            var currentorder =await _repository.GetUserCurrentOrder(request.UserId);
            if (currentorder == null)
                return OperationResult.NotFound();
            currentorder.RemoveItem(request.ItemId);
           await _repository.Save();
            return OperationResult.Success();

        }
    }
}
