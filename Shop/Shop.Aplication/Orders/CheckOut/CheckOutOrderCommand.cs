using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Orders.CheckOut
{
    public class CheckOutOrderCommand:IBaseCommand
    {
        public CheckOutOrderCommand(long userId, string shire, string city, string postalCode, 
            string postalAddress, string phonenumber, string name, string family, string nationalCode)
        {
            UserId = userId;
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
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Phonenumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
      private readonly  IOrderRepository _repository;

        public CheckOutOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentorder =await _repository.GetUserCurrentOrder(request.UserId);
            if (currentorder == null)
                return OperationResult.NotFound();
            var address = new OrderAddress(request.Shire,request.City,request.PostalCode,request.PostalAddress,request.Phonenumber
                ,request.Name,request.Family,request.NationalCode);
            currentorder.Checkout(address);
             await _repository.Save();
            return OperationResult.Success();
        }
    }
}
