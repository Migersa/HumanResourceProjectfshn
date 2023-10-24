using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.PermitDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class PermitDomain : DomainBase, IPermitDomain
    {
        public PermitDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) { }
        
        private IPermitRepository permitRepository => _unitOfWork.GetRepository<IPermitRepository>();

        public IList<PermitDTO1> GetAllPermit()
        {
            IEnumerable<Permit> permits = permitRepository.GetAll();
            return _mapper.Map<IList<PermitDTO1>>(permits);
        }
        
        public Permit CreatePermit(PermitDTO permit)
        {
            /*

            PermitDTO permit1 = new RoleDTO();
            permit1.RoleId = Guid.NewGuid();
            role1.Name = permit.Name;
            */

            var s = _mapper.Map<PermitDTO, Permit>(permit);
            permitRepository.Add(s);
            return s;
        }

        public Permit GetById(Guid id)
        {
            var roli = permitRepository.GetById(id);
            return roli;
        }
        public void Remove(Guid id)
        {
            permitRepository.Remove(id);
        }
        public void Update(PermitDTO1 permit)
        {
            var p = _mapper.Map<PermitDTO1, Permit>(permit);
            permitRepository.Update(p);
        }
    }
}
