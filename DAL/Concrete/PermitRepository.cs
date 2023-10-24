using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class PermitRepository : BaseRepository<Permit, Guid>, IPermitRepository
    {
        public PermitRepository(HumanResourcesContext dbContext) : base(dbContext) { }
       
        public Permit GetByEmployeeId(Guid id)
        {
            var permit = context.Where(a => a.EmployeeId == id).FirstOrDefault();
            return permit;
        }
        public Permit GetById(Guid id)
        {
            var permit = context.Where(a => a.Id == id).FirstOrDefault();
            return permit;
        }

        public Permit Add(Permit permit)
        {
            permit.Id = Guid.NewGuid();
            context.Add(permit);
            PersistChangesToTrackedEntities();
            return context.Add(permit).Entity;
        }

        public void Update(Permit permit)
        {
            if (db.Entry(permit).State == EntityState.Detached)
                context.Attach(permit);
            
            SetModified(permit);
            PersistChangesToTrackedEntities();
        }

        public void Remove(Guid id)
        {
            Permit PermitToRemove = context.Find(id);
            if (PermitToRemove != null)
                Remove(PermitToRemove);
            
            PersistChangesToTrackedEntities();
        }
    }
}
