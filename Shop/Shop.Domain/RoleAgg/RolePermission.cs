using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission:BaseEntity
    {
        public long RoleId { get; internal set; }
        public Permissions Permission { get; private set; }
    }
}
