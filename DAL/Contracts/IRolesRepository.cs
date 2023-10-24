using Entities.Model;

namespace DAL.Contracts
{
    public interface IRolesRepository : IRepository<Role, Guid>
    {
        Guid Findid(String role);
        Role Add(Role roli);
        Role GetById(Guid id);
        void Update(Role roli);
        void Remove(Guid id);
        Role GetByRoleName(string name);
        IEnumerable<Role> GetAll();
    }
}
