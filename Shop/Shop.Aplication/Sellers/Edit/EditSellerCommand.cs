using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Sellers.Edit
{
    public class EditSellerCommand:IBaseCommand
    {
        public EditSellerCommand(long userId, string shopName, string nationalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
    }
}
