using AutoMapper;
using DAL.UoW;
using Domain.Contracts;
using DTO.RoleDTO;
using Microsoft.AspNetCore.Http;
using DAL.Contracts;
using Entities.Model;
using DTO.RoleDTO1;

namespace Domain.Concrete
{
    internal class RoleDomain : DomainBase, IRoleDomain
    {
        public RoleDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) { }
        
        private IRolesRepository roleRepository => _unitOfWork.GetRepository<IRolesRepository>();
        public IList<RoleDTO> GetAllRoles()
        {
            IEnumerable<Role> user = roleRepository.GetAll();
            return _mapper.Map<IList<RoleDTO>>(user);
        }

        public Role CreateRole(RoleDTO1 roli)
        {
            RoleDTO role1 = new RoleDTO();
            role1.RoleId = Guid.NewGuid();
            role1.Name = roli.Name;
            var s = _mapper.Map<RoleDTO, Role>(role1);
            roleRepository.Add(s);
            return s;
        }

        public Role GetByRoleName(string name)
        {
            var roli = roleRepository.GetByRoleName(name);
            return roli;
        }

        public Role GetById(Guid id)
        {
            var roli = roleRepository.GetById(id);
            return roli;
        }

        public void Remove(Guid id)
        {
            roleRepository.Remove(id);
        }

        public void Update(RoleDTO role)
        {
            var p = _mapper.Map<RoleDTO, Role>(role);
            roleRepository.Update(p);
        }
    }
}
