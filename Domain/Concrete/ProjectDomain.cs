using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.ProjectDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class ProjectDomain : DomainBase, IProjectDomain
    {
        public ProjectDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IProjectRepository projectsRepository => _unitOfWork.GetRepository<IProjectRepository>();


        public IList<ProjectDTO> GetAllProjects()
        {
            IEnumerable<Project> projects = projectsRepository.GetAll();
            var test = _mapper.Map<IList<ProjectDTO>>(projects);
            return test;

        }
        public ProjectDTO GetProjectById(Guid id)
        {
            Project project = projectsRepository.GetById(id);
            return _mapper.Map<ProjectDTO>(project);
        }

        public ProjectDTO1 GetProjectByName(string name)
        {
            Project project = projectsRepository.GetByName(name);
            return _mapper.Map<ProjectDTO1>(project);
        }

        public void CreateProject(ProjectDTO project)
        {
            //ProjectDTO projectDTO = new ProjectDTO()
            //{
            //    Id = project.Id,
            //    Names = project.Names,
            //    DateFrom = project.DateFrom,
            //    DateTo = project.DateTo
            //};

            Project addproject = _mapper.Map<Project>(project);
            projectsRepository.Add(addproject);

        }

        public void Update(ProjectDTO project)
        {
            var updateproject = _mapper.Map<Project>(project);
            projectsRepository.Detach(updateproject);
            projectsRepository.Update(updateproject);

        }



        public void Remove(Guid id)
        {
            projectsRepository.Remove(id);

        }
    }
}
