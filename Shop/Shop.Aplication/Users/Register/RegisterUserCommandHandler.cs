using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Aplication.Users.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IDomainUserService _service;

        public RegisterUserCommandHandler(IUserRepository repository, IDomainUserService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Register(request.PhoneNumber.Value, request.Password, _service);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
