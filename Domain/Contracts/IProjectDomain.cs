using DTO.ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IProjectDomain
    {
        IList<ProjectDTO> GetAllProjects();
        ProjectDTO1 GetProjectByName(string name);

        ProjectDTO GetProjectById(Guid id);

        void CreateProject(ProjectDTO project);

        void Update(ProjectDTO project);

        void Remove(Guid id);
    }
}
