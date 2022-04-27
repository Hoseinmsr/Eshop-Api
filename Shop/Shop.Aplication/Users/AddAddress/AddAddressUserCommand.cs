using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.AddAddress
{
    public class AddAddressUserCommand:IBaseCommand
    {
        public AddAddressUserCommand(string shire, string city, string postalCode, string postalAddress,
            PhoneNumber phonenumber, string name, string family, string nationalCode, long userId)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phonenumber = phonenumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            UserId = userId;
        }

        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber Phonenumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}
