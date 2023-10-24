using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class EducationRepository: BaseRepository<Education, Guid>, IEducationRepository
    {
        public EducationRepository(HumanResourcesContext dbContext) : base(dbContext) { }
        
        public Education GetById(Guid id)
        {
            var education = context.Where(a => a.Id == id).FirstOrDefault();
            return education;
        }

        public Education Add(Education education)
        {
            context.Add(education);
            PersistChangesToTrackedEntities();
            return context.Add(education).Entity;
        }

        public void Update(Education education)
        {
            if (db.Entry(education).State == EntityState.Detached)
                context.Attach(education);
            
            //context.Update(project);
            SetModified(education);
            PersistChangesToTrackedEntities();
        }

        public void Remove(Guid id)
        {
            Education educationToRemove = context.Find(id);
            if (educationToRemove != null)
                Remove(educationToRemove);

            PersistChangesToTrackedEntities();
        }
    }
}
