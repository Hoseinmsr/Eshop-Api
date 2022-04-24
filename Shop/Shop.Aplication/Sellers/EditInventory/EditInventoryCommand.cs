using Common.Application;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Sellers.EditInventory
{
    public class EditInventoryCommand:IBaseCommand
    {
        public EditInventoryCommand(long sellerId, long inventoryId, int count, int price, int? percentageDiscount, SellerStatus status)
        {
            SellerId = sellerId;
            InventoryId = inventoryId;
            Count = count;
            Price = price;
            PercentageDiscount = percentageDiscount;
            Status = status;
        }

        public long SellerId { get; private set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PercentageDiscount { get; private set; }
        public SellerStatus Status { get; private set; }
    }
}
