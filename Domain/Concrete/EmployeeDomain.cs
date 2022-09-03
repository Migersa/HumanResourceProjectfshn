using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.EmployeeDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class EmployeeDomain : DomainBase, IEmployeeDomain
    {
        public EmployeeDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IEmployeeRepository employeeRepository => _unitOfWork.GetRepository<IEmployeeRepository>();

        private IEmailRepository emailRepository => _unitOfWork.GetRepository<IEmailRepository>();

        public IList<EmployeeDTO> GetAllUsers()
        {
            IEnumerable<Employee> user = employeeRepository.GetAll();
            var test = _mapper.Map<IList<EmployeeDTO>>(user);
            return test;
        }

        public EmployeeDTO GetUserById(Guid id)
        {
            Employee user = employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDTO>(user);
        }

        public EmployeeDTO Create(EmployeeDTO employee)
        {

            Employee user = _mapper.Map<Employee>(employee);
            user.Id = Guid.NewGuid();


            // List<UserRole> userRole = new List<UserRole>();

            foreach (var item in employee.RoleId)
            {

                UserRole x = new UserRole();
                x.PunonjesId = user.Id;
                x.RoleId = item;
                user.UserRoles.Add(x);

            }


            //user.UserRoles = userRole;



            string password = employeeRepository.generatePassword();
            string newEmail = employee.Username.ToLower().Replace(" ", String.Empty) + "@3isolutions.com";


            string subject = "Welcome " + user.Username + "!";
            string body = "Below you will find your credentials. " + Environment.NewLine +
                           "Website URL: https://localhost:44302/swagger/index.html " + Environment.NewLine +
                           "Email: " + newEmail + Environment.NewLine +
                           "Password: " + password;



            emailRepository.SendEmail(user, subject, body);

            byte[] passwordHash = employeeRepository.createPasswordHash(password);

            user.PasswordHash = passwordHash;
            employeeRepository.Create(user);


            /* user.Email = newEmail;

             employeeRepository.Update(user);*/
            return _mapper.Map<EmployeeDTO>(user);
        }

        public void Update(EmployeeDTO1 employee)
        {
            var updateproject = _mapper.Map<Employee>(employee);
            /*string password = "8MudGI3Y";
            employeeRepository.createPasswordHash(password, out byte[] passwordHash);
            updateproject.PasswordHash = passwordHash;*/



            employeeRepository.Update(updateproject);

        }
    }
}
