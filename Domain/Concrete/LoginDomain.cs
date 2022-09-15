using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class LoginDomain : DomainBase, ILoginDomain
    {
        public LoginDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {

        }
        private ILoginRepository loginRepository => _unitOfWork.GetRepository<ILoginRepository>();

        public  LoginDTO AuthUsers(LoginCredentialsDTO dto)
        {


            var data = _mapper.Map<LoginCredentialsDTO, Employee>(dto);
            var login = loginRepository.Generate(data);

            if (login == null) { return null; }
            else
            {
                string passwordStr = Convert.ToBase64String(login.PasswordHash);
                var passChanged = passwordStr.Remove(8, 1).Insert(8, ":");
                string[] pass = passChanged.Split(":");
                string pass1 = pass[0];


                if (pass1.Equals(dto.Password))
                {
                    var result = _mapper.Map<Employee, LoginDTO>(login);
                    
                    return result;
                }
                return null;
            }
        }
            



    }
}
