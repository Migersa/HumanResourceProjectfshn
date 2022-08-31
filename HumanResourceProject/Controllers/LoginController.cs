using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public static LoginDTO auth = new LoginDTO();
        private IConfiguration _config;
        private readonly ILoginDomain _loginDomain;

        public LoginController(IConfiguration config, ILoginDomain loginDomain)
        {
            _config = config;
            _loginDomain = loginDomain;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("loginAuthentication")]
        public IActionResult Authenticate([FromBody] LoginCredentialsDTO login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(login);
                }
                
               
                auth = _loginDomain.GetAllUsers(login);
                if (auth != null)
                {
                    var token = Generate(auth);
                    var refreshToken = GenerateRefreshToken();
                    SetRefreshToken(refreshToken);
                    return Ok(token);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserLoginById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _loginDomain.GetUserById(userId);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var hi = auth.RefreshToken;

            if (!auth.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (auth.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = Generate(auth);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
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
        private string Generate(LoginDTO dto)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            //var claims = new[]
            //{
            //   // new Claim(ClaimTypes.NameIdentifier,dto.Username),
            //   // new Claim(ClaimTypes.Email,dto.///Email),
                

            //};

            var token = new JwtSecurityToken(_config["jwt:validissuer"],
                _config["jwt:validaudience"],
                //claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
