using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.Create
{
    public class CreateUserCommand:IBaseCommand
    {
        public CreateUserCommand(string name, string family, string email, string phonenumber, string password, Gender gender)
        {
            Name = name;
            Family = family;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public string Phonenumber { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
    }
}
