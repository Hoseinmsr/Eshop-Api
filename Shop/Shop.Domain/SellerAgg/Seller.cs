using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userid,string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            UserId = userid;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? Lastupdate { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; set; }



        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            Lastupdate = DateTime.Now;
        }
        public void Edit(string shopname,string nationalcode)
        {
            Guard(shopname, nationalcode);
            ShopName = shopname;
            NationalCode = nationalcode;
        }
        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(x => x.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");
            Inventories.Add(inventory);
        }
        public void EditInventory(SellerInventory newinventory)
        {
           var currentinventory = Inventories.FirstOrDefault(f=>f.Id==newinventory.Id);
            if (currentinventory == null)
                return;
            Inventories.Remove(currentinventory);
            Inventories.Add(newinventory);
        }
        public void DeleteInventory(long inventoryid)
        {
            var currentinventory = Inventories.FirstOrDefault(f => f.Id == inventoryid);
            if (currentinventory == null)
                throw new NullOrEmptyDomainDataException();
            Inventories.Remove(currentinventory);
        }
        public void Guard(string shopname, string nationalcode)
        {
            NullOrEmptyDomainDataException.CheckString(shopname, nameof(shopname));
            NullOrEmptyDomainDataException.CheckString(nationalcode, nameof(nationalcode));
            if (IranianNationalIdChecker.IsValid(nationalcode) == false)
                throw new InvalidDomainDataException("شماره ملی وارد شده صحیح نمیباشد");
        }
    }

}
