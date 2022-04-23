using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.RoleAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Roles.Edit
{
    public record EditRoleCommand(long Id,string Title,List<Permissions> Permissions):IBaseCommand;
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public EditRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role =await _repository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(f =>
            {
                permissions.Add(new RolePermission(f));
            });
            role.SetPermission(permissions);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
