using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class LoginRepository : BaseRepository<Employee, Guid>, ILoginRepository
    {
        public LoginRepository(HumanResourcesContext dbContext) : base(dbContext) { }
        public Employee? Generate(Employee employee)
        {
            var login = context.Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(a => a.Username == employee.Username).FirstOrDefault();
            return login ?? null; 
        }
    }
}
