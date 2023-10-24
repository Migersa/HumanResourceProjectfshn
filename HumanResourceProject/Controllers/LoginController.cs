using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        public static RoleDTO role = new RoleDTO();
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
                auth = _loginDomain.AuthUsers(login);
                if (auth != null)
                {
                    var token = _loginDomain.GenerateAccessAndRefreshToken();
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

            var token = _loginDomain.GenerateAccessAndRefreshToken();
            return Ok(token);
        }
    }
}
