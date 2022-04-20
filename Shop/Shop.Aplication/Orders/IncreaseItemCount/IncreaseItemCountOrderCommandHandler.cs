using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Aplication.Orders.IncreaseItemCount
{
    public class IncreaseItemCountOrderCommandHandler : IBaseCommandHandler<IncreaseItemCountOrderCommand>
    {
       private readonly IOrderRepository _repository;

        public IncreaseItemCountOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseItemCountOrderCommand request, CancellationToken cancellationToken)
        {
            var currentorder =await _repository.GetUserCurrentOrder(request.UserId);
            if (currentorder == null)
                return OperationResult.NotFound();
            currentorder.IncreaseItemCount(request.ItemId, request.Count);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
