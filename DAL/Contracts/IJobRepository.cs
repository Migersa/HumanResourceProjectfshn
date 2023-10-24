using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IJobRepository: IRepository<Job,Guid>
    {
        Job GetById(Guid id);
        Job Add(Job job);
        void Update(Job job);
        void Remove(Guid id);
    }
}
