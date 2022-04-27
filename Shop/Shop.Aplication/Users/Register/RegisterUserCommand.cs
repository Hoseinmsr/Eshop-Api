using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.Register
{
    public class RegisterUserCommand:IBaseCommand
    {
        public RegisterUserCommand(string password, PhoneNumber phoneNumber)
        {
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public string Password { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
    }
}
