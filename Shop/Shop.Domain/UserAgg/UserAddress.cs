using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string shire, string city, string postalCode, string postalAddress, string phonenumber, string name, string family, string nationalCode)
        {
            Guard(shire, city, postalCode, postalAddress, phonenumber, name, family, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phonenumber = phonenumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Phonenumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAdress { get; private set; }

        public void Edit(string shire, string city, string postalCode, string postalAddress, string phonenumber, string name, string family, string nationalCode)
        {
            Guard(shire,city,postalCode,postalAddress,phonenumber,name,family,nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Phonenumber = phonenumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            ActiveAdress = false;
        }
        public void SetActive()
        {
            ActiveAdress = true;
        }
        public void Guard(string shire, string city, string postalCode, string postalAddress, string phonenumber, string name, string family, string nationalCod)
        {
            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(phonenumber, nameof(phonenumber));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalCod, nameof(nationalCod));

            if (IranianNationalIdChecker.IsValid(nationalCod) == false)
                throw new InvalidDomainDataException("شماره ملی نا معتبر است");
        }
    }
}
