using AutoMapper;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        #region User
        public GeneralProfile()
        {
           CreateMap<Employee, LoginDTO>().ReverseMap();
           CreateMap<Employee, UserDTO>().ReverseMap();
          // CreateMap<LoginCredentialsDTO, Employee>().ForSourceMember(x => x.Password, opt => opt.DoNotValidate());
           CreateMap<Education, EducationDTO>().ReverseMap();


        }
        

        #endregion


    }
}
