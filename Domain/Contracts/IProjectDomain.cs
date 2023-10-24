using DTO.ProjectDTO;


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
