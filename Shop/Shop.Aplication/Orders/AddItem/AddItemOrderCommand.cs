﻿using Common.Application;
using Common.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Orders.AddItem
{
    public class AddItemOrderCommand : IBaseCommand
    {
        public AddItemOrderCommand(long inventoryId, int count, long userId)
        {
            InventoryId = inventoryId;
            Count = count;
            UserId = userId;
        }

        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public long UserId { get; private set; }
    }
}
