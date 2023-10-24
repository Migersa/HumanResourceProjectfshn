using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class ArchiveRepository : BaseRepository<Archive, Guid>, IArchiveRepository
    {
        public ArchiveRepository(HumanResourcesContext dbContext) : base(dbContext) { }
        
        public Archive GetByEmployeeId(Guid id)
        {
            var archive = context.Where(a => a.EmployeeId == id).FirstOrDefault();
            return archive;
        }
        public Archive GetById(Guid id)
        {
            var archive = context.Where(a => a.Id == id).FirstOrDefault();
            return archive;
        }

        public Archive Add(Archive archive)
        {
            archive.Id = Guid.NewGuid();

            context.Add(archive);
            PersistChangesToTrackedEntities();
            return context.Add(archive).Entity;
        }

        public void Update(Archive archive)
        {
            if (db.Entry(archive).State == EntityState.Detached)
            {
                context.Attach(archive);
            }
            //context.Update(project);
            SetModified(archive);
            PersistChangesToTrackedEntities();
        }
        public void Remove(Guid id)
        {
            Archive ArchiveToRemove = context.Find(id);
            if (ArchiveToRemove != null)
            {
                Remove(ArchiveToRemove);
            }
            PersistChangesToTrackedEntities();
        }
    }
}
