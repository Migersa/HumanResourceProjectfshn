using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using DTO.RefreshTokenDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Domain.Concrete
{
    internal class LoginDomain : DomainBase, ILoginDomain
    {
        private IConfiguration _config;
        public static LoginDTO auth = new LoginDTO();
        public static RoleDTO role = new RoleDTO();
        public LoginDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(unitOfWork, mapper, httpContextAccessor)
        { _config = config; }

        private ILoginRepository loginRepository => _unitOfWork.GetRepository<ILoginRepository>();

        public LoginDTO AuthUsers(LoginCredentialsDTO dto)
        {
            
                var data = _mapper.Map<LoginCredentialsDTO, Employee>(dto);
                var login = loginRepository.Generate(data);

                var stringPassword = (login == null) ? ConvertHashToString(login) : throw new Exception("login is null");
                return (stringPassword.Equals(dto.Password)) ? auth = _mapper.Map<Employee, LoginDTO>(login) :throw new Exception("fdf");
        }


        public string GenerateAccessAndRefreshToken()
        {
            var roleList = auth.UserRoles;
            foreach (var roleName in roleList)
            {
                role.Name = roleName.Role.Name;
            }
            var token = Generate(auth, role);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);
            return token;
        }

        private static string ConvertHashToString(Employee? login)
        {
            string passwordStr = Convert.ToBase64String(login.PasswordHash);
            var passChanged = (passwordStr.Remove(8, 1).Insert(8, ":")).Split(":");
            string pass1 = passChanged[0];
            return pass1;
        }

        public RefreshTokenDTO GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenDTO
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        public void SetRefreshToken(RefreshTokenDTO newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            auth.RefreshToken = newRefreshToken.Token;
            auth.TokenCreated = newRefreshToken.Created;
            auth.TokenExpires = newRefreshToken.Expires;
        }
        public string Generate(LoginDTO dto, RoleDTO role)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,dto.Username),
                new Claim(ClaimTypes.Role,role.Name),

            };

            var token = new JwtSecurityToken(_config["jwt:validissuer"],
                _config["jwt:validaudience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    } 
}
    

