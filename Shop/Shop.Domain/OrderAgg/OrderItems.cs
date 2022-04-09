using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class Orderitems:BaseEntity
    {
        public Orderitems(long inventoryId, int count, int price)
        {
            PriceGuard(price);
            CountGuard(count);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long UserId { get;internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price * Count;


        public void ChangeCount(int newcount)
        {
            CountGuard(newcount);
            Count = newcount;
        }
        public void SetPrice(int newprice)
        {
            PriceGuard(newprice);
            Price = newprice;
        }
        public void PriceGuard(int newprice)
        {
            if (newprice < 0)
                throw new InvalidDomainDataException("مبلغ کمتر از حداقل است");
        }
        public void CountGuard(int newcount)
        {
            if (newcount < 1)
                throw new InvalidDomainDataException("تعداد کمتر از حداقل است");
        }
    }
}
