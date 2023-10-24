using Entities.Model;

namespace DAL.Contracts
{
    public interface IPermitRepository : IRepository<Permit, Guid>
    {
        Permit GetByEmployeeId(Guid id);
        Permit GetById(Guid id);
        Permit Add(Permit permit);
        void Update(Permit permit);
        void Remove(Guid id);
    }
}
