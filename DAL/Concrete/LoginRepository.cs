using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Concrete
{
    internal class LoginRepository : BaseRepository<Employee, Guid>, ILoginRepository
    {
       

        public LoginRepository(HumanResourcesContext dbContext) : base(dbContext)
        {
        }

        public Employee Generate(Employee employee)
        {


            
            
            var login = context.Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(a => a.Username == employee.Username).FirstOrDefault();
            if (login != null)
            {
             
                    return login;

                
            }

            
            return null;
            }

       

        //private bool VerifyPasswordHash(string password, byte[] passwordHash)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != passwordHash[i]) return false;
        //        }
        //        return true;
        //    }
        //}


    }
}
