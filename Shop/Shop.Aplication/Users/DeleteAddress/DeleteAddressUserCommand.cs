using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.DeleteAddress
{
    public class DeleteAddressUserCommand:IBaseCommand
    {
        public DeleteAddressUserCommand(long userId, long addressId)
        {
            UserId = userId;
            AddressId = addressId;
        }

        public long UserId { get; private set; }
        public long AddressId { get; private set; }
    }
}
