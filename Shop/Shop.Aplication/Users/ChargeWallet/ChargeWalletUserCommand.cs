using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.ChargeWallet
{
    public class ChargeWalletUserCommand:IBaseCommand
    {
        public ChargeWalletUserCommand(long userId, int price, string description, WalletType type, bool isFinally)
        {
            UserId = userId;
            Price = price;
            Description = description;
            Type = type;
            IsFinally = isFinally;
        }

        public long UserId { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public WalletType Type { get; private set; }
    }
}
