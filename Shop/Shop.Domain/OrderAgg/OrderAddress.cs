﻿using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        public OrderAddress(string shire, string city, string postalCode, string postalAddress, string phonenumber,
            string name, string family, string nationalCode)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phonenumber = phonenumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public long OrderId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Phonenumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        public Order order { get; set; }
    }
}
