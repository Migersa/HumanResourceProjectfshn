using AutoMapper;
using DTO.EducationDTO;
using DTO.EmployeeDTO;
using DTO.LoginDTO;
using DTO.ProjectDTO;
using DTO.UserDTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           CreateMap<Employee, LoginDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<Employee, EmployeDTO>().ReverseMap();
           CreateMap<LoginCredentialsDTO, Employee>().ForSourceMember(x => x.Password, opt => opt.DoNotValidate());
           CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<Employee, DTO.EmployeeDTO.EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO1>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO1>().ReverseMap();


        }
        

        
        


    }
}
