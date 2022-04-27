using Common.Application;
using Common.Application.Validation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.Edit
{
    public class EditUserCommand:IBaseCommand
    {
        public EditUserCommand(long userId, string name, string family, string email,
            string phonenumber, string password, IFormFile? avatar, Gender gender)
        {
            UserId = userId;
            Name = name;
            Family = family;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
            Avatar = avatar;
            Gender = gender;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public string Phonenumber { get; private set; }
        public string Password { get; private set; }
        public IFormFile? Avatar { get; private set; }
        public Gender Gender { get; private set; }
    }
}
