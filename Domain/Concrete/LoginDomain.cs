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

        public  LoginDTO GetAllUsers(LoginCredentialsDTO dto)
        {


            
            var data = _mapper.Map<LoginCredentialsDTO, Employee>(dto);
            var login = loginRepository.Generate(data);


            var verify = VerifyPasswordHash(dto.Password, login.PasswordHash);

            byte[] bytes = Convert.FromBase64String(dto.Password);
            string credentials = Encoding.UTF8.GetString(bytes);

            if (bytes.Equals(dto.Password))
            {
                var result = _mapper.Map<Employee, LoginDTO>(login);
                return result;
            }
            return null;
            }
            
        

        public EmployeDTO GetUserById(Guid id)
        {
            Employee user = loginRepository.GetById(id);
            return _mapper.Map<EmployeDTO>(user);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            //    for (int i = 0; i < computedHash.Length; i++)
            //    {
            //        if (computedHash[i] != passwordHash[i])
            //        {

            //            return false;
            //        }
            //    }
            //    return true;
            
            return computedHash.SequenceEqual(passwordHash);
            }
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


    }
}
