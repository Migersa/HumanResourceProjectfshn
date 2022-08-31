using AutoMapper;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using DTO.EducationDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Contracts;

using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class EducationDomain : DomainBase, IEducationDomain
    {
        public EducationDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {

        }
        private IEducationRepository educationRepository => _unitOfWork.GetRepository<IEducationRepository>();

        public EducationDTO Add(EducationDTO education)
        {
            var data = _mapper.Map<EducationDTO, Education>(education);
            var educationData = educationRepository.Add(data);

            var educationDTOdata = _mapper.Map<Education, EducationDTO>(educationData);
            return educationDTOdata;


        }

        public EducationDTO GetEducationById(Guid id)
        {
            Education user = educationRepository.GetById(id);
            return _mapper.Map<EducationDTO>(user);
        }

        public void Remove(Guid id)
        {
            educationRepository.Remove(id);
        }

        public void Update(EducationDTO education)
        {
            var edu = educationRepository.GetById(education.Id);
            if (edu != null)
            {
                educationRepository.Update(edu);
                
            }
        }
    }
}
