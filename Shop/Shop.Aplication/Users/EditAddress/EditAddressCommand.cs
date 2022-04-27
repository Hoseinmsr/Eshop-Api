using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Users.EditAddress
{
    public class EditAddressCommand:IBaseCommand
    {
        public EditAddressCommand( string shire, string city, string postalCode, string postalAddress,
            PhoneNumber phonenumber, string name, string family, string nationalCode)
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
        public long UserId { get; private set; }
        public long Id { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber Phonenumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
    public class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
    {
        private readonly IUserRepository _repository;

        public EditAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            var user =await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var useraddress = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress
                , request.Phonenumber, request.Name, request.Family, request.NationalCode);
            user.EditAddress(useraddress, request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
