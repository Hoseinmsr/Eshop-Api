using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order:AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<Orderitems>();
        }

        public long UserId { get; set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public List<Orderitems> Items { get; private set; }

        public ShippingMethod? shippingmethod { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public int TotlaPrice
        {
            get
            {
                var totalprice = Items.Sum(s => s.TotalPrice);
                if (shippingmethod != null)
                    totalprice += shippingmethod.ShippingCost;
                if (Discount != null)
                    totalprice -= Discount.DiscountAmount;
                return totalprice;
            }
        }
        public OrderAddress? Address { get;private set; }
        public int ItemCount => Items.Count;



        public void AddItem(Orderitems items)
        {
           ChangeOrderGuard();
            var olditem = Items.FirstOrDefault(f => f.InventoryId == items.InventoryId);
            if (olditem != null)
            {
                olditem.ChangeCount(items.Count + olditem.Count); 
            }
            Items.Add(items);
        }
        public void RemoveItem(long itemid)
        {
            ChangeOrderGuard();
            var currentitem = Items.FirstOrDefault(f => f.Id == itemid);
            if(currentitem!=null)
                Items.Remove(currentitem);
        }
        public void ChangeCountItem(long itemid,int newcount)
        {
            ChangeOrderGuard();
            var currentitem = Items.FirstOrDefault(f => f.Id == itemid);
            if (currentitem == null)
                throw new NullOrEmptyDomainDataException();
            currentitem.ChangeCount(newcount);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Checkout(OrderAddress orderAddress)
        {
            ChangeOrderGuard();
            Address = orderAddress;
        }
        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidDomainDataException("امکان ثبت محصول در این سفارش ممکن نمی باشد");
        }

    }
}
