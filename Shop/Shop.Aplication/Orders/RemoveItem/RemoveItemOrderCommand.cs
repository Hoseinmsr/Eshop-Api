﻿using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Orders.RemoveItem
{
    public record RemoveItemOrderCommand(long UserId,long ItemId):IBaseCommand;
}
