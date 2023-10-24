using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ILoginRepository : IRepository<Employee, Guid>
    {
       Employee? Generate(Employee emp);
    }
}
