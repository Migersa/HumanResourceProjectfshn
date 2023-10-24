using Entities.Model;

namespace DAL.Contracts
{
    public interface IProjectRepository : IRepository<Project, Guid>
    {
        Project GetByName(string name);
        Project GetById(Guid id);
        Project Add(Project project);
        void Update(Project project);
        void Remove(Guid id);


    }
}
