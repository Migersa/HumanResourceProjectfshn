using DTO.ArchiveDTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IArchiveDomain
    {
        IList<ArchiveDTO1> GetAllArchives();
        Archive CreateArchive(ArchiveDTO archive);
        Archive GetById(Guid id);
        void Remove(Guid id);
        void Update(ArchiveDTO1 archive);
    }
}
