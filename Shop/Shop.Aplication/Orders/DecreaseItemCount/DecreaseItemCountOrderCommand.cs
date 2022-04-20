using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Orders.DecreaseItemCount
{
    public record DecreaseItemCountOrderCommand(long UserId,long ItemId,int Count):IBaseCommand;

}
