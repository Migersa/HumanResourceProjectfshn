using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
