using DTO.RoleDTO;
using DTO.RoleDTO1;
using Entities.Model;

namespace Domain.Contracts
{
    public interface IRoleDomain
    {
        Role CreateRole(RoleDTO1 roli);
        Role GetByRoleName(string name);
        Role GetById(Guid id);
        void Remove(Guid id);
        IList<RoleDTO> GetAllRoles();
        void Update(RoleDTO role);
    }
}
