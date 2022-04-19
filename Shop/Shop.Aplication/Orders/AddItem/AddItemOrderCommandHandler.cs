using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Aplication.Orders.AddItem
{
    public class AddItemOrderCommandHandler : IBaseCommandHandler<AddItemOrderCommand>
    {
       private readonly ISellerRepository _sellerrepository;
       private readonly IOrderRepository _repository;

        public AddItemOrderCommandHandler(ISellerRepository sellerrepository, IOrderRepository repository)
        {
            _sellerrepository = sellerrepository;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddItemOrderCommand request, CancellationToken cancellationToken)
        {
            var inventory =await _sellerrepository.GetInventoryById(request.InventoryId);
            if (inventory == null)
                return OperationResult.NotFound();
            if (inventory.Count < request.Count)
            {
                return OperationResult.Error("به اندازه کافی در انبار موجود نمیباشد");
            }
            var order = await _repository.GetUserCurrentOrder(request.UserId);
            if(order==null)
               order = new Order(request.UserId);


            order.AddItem(new Domain.OrderAgg.Orderitems(request.InventoryId, request.Count, inventory.Price));
            if (ItemCountBiggerThanInventoryCount(inventory,order))
            {
                return OperationResult.Error("به اندازه کافی در انبار موجود نمیباشد");
            }

            await _repository.Save();
            return OperationResult.Success();
        }
        private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory,Order order)
        {
            var orderitem = order.Items.First(f => f.InventoryId == inventory.Id);
            if (orderitem.Count > inventory.Count)
                return true;
            return false;
        }
    }
}
