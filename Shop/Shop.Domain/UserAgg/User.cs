using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string email, string phonenumber, string password, Gender gender,
            IDomainUserService domainservice)
        {
            Guard(email, phonenumber, domainservice);
            Name = name;
            Family = family;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
            Gender = gender;
            AvatarName = "avatar.png";
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public string Phonenumber { get; private set; }
        public string AvatarName { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }



        public void Edit(string name, string family, string email, string phonenumber, Gender gender,IDomainUserService domainservice)
        {
            Guard(email, phonenumber,domainservice);
            Name = name;
            Family = family;
            Email = email;
            Phonenumber = phonenumber;
            Gender = gender;
        }
        public static User Register(string email,string phonenumber,string password, IDomainUserService domainservice)
        {
            return new User("", "", email,phonenumber, password, Gender.None, domainservice);
        }
        public void SetAvatar(string imagename)
        {
            if (string.IsNullOrWhiteSpace(imagename))
                imagename = "avatar.png";
            AvatarName = imagename;
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldadress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (oldadress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            Addresses.Remove(oldadress);
            Addresses.Add(address);
        }
        public void DeleteAddress(long addresid)
        {
            var oldadress = Addresses.FirstOrDefault(f => f.Id == addresid);
            if (oldadress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            Addresses.Remove(oldadress);
        }
        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
        public void Guard(string email, string phonenumber,IDomainUserService domainservice)
        {
            NullOrEmptyDomainDataException.CheckString(phonenumber, nameof(phonenumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phonenumber.Length != 11)
                throw new InvalidDomainDataException("شماره وارد شده معتبر نمیباشد");
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل وارد شده نا معتبر است");
            if (phonenumber != Phonenumber)
                if (domainservice.IsPhonenumberExist(phonenumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");
            if (email != Email)
                if (domainservice.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
