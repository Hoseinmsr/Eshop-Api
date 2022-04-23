using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission:BaseEntity
    {
        public RolePermission(Permissions permission)
        {
            Permission = permission;
        }

        public long RoleId { get; internal set; }
        public Permissions Permission { get; private set; }
    }
}
