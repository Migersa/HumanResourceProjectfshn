using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class JobRepository : BaseRepository<Job, Guid>, IJobRepository
    {

        public JobRepository(HumanResourcesContext dbContext) : base(dbContext) { }
        
        public Job GetById(Guid id)
        {
            var job = context.Where(a => a.Id == id).FirstOrDefault();
            return job;
        }

        public Job Add(Job job)
        {
            context.Add(job);
            PersistChangesToTrackedEntities();
            return context.Add(job).Entity;
        }

        public void Update(Job job)
        {
            if (db.Entry(job).State == EntityState.Detached)
                context.Attach(job);
            
            SetModified(job);
            PersistChangesToTrackedEntities();
        }

        public void Remove(Guid id)
        {
            Job jobToRemove = context.Find(id);
            if(jobToRemove != null) 
                Remove(jobToRemove);
            
            PersistChangesToTrackedEntities();
        }
    }
}
