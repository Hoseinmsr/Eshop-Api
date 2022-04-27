using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Aplication.Users.AddAddress
{
    internal class AddAddressUserCommandHandler : IBaseCommandHandler<AddAddressUserCommand>
    {
        private readonly IUserRepository _repository;

        public AddAddressUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var useraddress = new UserAddress(request.Shire,request.City,request.PostalCode,request.PostalAddress
                ,request.Phonenumber,request.Name,request.Family,request.NationalCode);
            user.AddAddress(useraddress);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
