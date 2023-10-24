using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.ArchiveDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;

namespace Domain.Concrete
{
    internal class ArchiveDomain : DomainBase, IArchiveDomain
    {
        public ArchiveDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) { }
       
        private IArchiveRepository archiveRepository => _unitOfWork.GetRepository<IArchiveRepository>();

        public IList<ArchiveDTO1> GetAllArchives()
        {
            IEnumerable<Archive> archives = archiveRepository.GetAll();
            return _mapper.Map<IList<ArchiveDTO1>>(archives);
        }

        public Archive CreateArchive(ArchiveDTO archive)
        {
            var s = _mapper.Map<ArchiveDTO, Archive>(archive);
            archiveRepository.Add(s);
            return s;
        }

        public Archive GetById(Guid id)
        {
            return archiveRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            archiveRepository.Remove(id);
        }

        public void Update(ArchiveDTO1 archive)
        {
            var p = _mapper.Map<ArchiveDTO1, Archive>(archive);
            archiveRepository.Update(p);
        }
    }
}
