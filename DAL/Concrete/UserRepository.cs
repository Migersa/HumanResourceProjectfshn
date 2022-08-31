using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {

        public UserRepository(HumanResourcesContext dbContext) : base(dbContext)
        {
        }//

        public Employee GetById(Guid id)
        {
            var user = context.Where(a => a.Id == id).FirstOrDefault();
            return user;
        }


    }
    */

}
