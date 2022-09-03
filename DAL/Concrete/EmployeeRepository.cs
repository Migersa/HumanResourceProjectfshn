using DAL.Contracts;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class EmployeeRepository : BaseRepository<Employee, Guid>, IEmployeeRepository
    {

        public EmployeeRepository(HumanResourcesContext dbContext) : base(dbContext)
        {
        }
        protected readonly IEmailRepository emailRepository;





        public byte[] createPasswordHash(string password)
        {
            /*using(var hmac = new HMACSHA512())
            {
                
                passwordHash =  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }*/
            byte[] bytes = Convert.FromBase64String(password);
            return bytes;
            //byte[] bytes = Convert.FromBase64String(base64);
        }

        /* public static string Base64Decode(string base64EncodedData)
         {
             var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
             return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
         }*/

        static List<char> chars = new List<char>() { 'a','b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'y', 'x', 'z', 'w',
                                                      'A','B', 'C','D', 'E','F', 'G','H', 'I','J', 'K','L', 'M','N', 'O','P', 'Q','R', 'S','T', 'U','V', 'Y','X', 'Z','W',
                                                        '0','1','2', '3','4', '5','6', '7','8', '9'};

        public string generatePassword()
        {
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            int i = 0;

            while (i < 8)
            {
                sb.Append(chars[rd.Next(0, chars.Count)]);
                i++;
            }
            return sb.ToString();
        }

        /*public static void addChars(ref List<char> chars)
        {
            for(char c = 'a';c <= 'z'; c++)
            {
                chars.Add(c);
            }
            for(char c = 'A';c <= 'Z'; c++)
            {
                chars.Add(c);
            }
            for(char c = '!';c <= '?'; c++)
            {
                chars.Add(c);
            }
            for(char c = '0';c <= '9'; c++)
            {
                chars.Add(c);
            }
        }*/



        public void Create(Employee employee)
        {


            context.Add(employee);
            db.SaveChanges();


        }

        public void Update(Employee employee)
        {
            Detach(employee);
            context.Update(employee);
            PersistChangesToTrackedEntities();

        }


        public Employee GetById(Guid id)
        {
            var user = context.Where(a => a.Id == id).FirstOrDefault();
            return user;
        }



    }

}
