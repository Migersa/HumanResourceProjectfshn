using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IEducationRepository:IRepository <Education, Guid>
    {
        Education GetById(Guid id);
        Education Add(Education entity);
        void Update(Education education);

        void Remove(Guid id);
    }
}
