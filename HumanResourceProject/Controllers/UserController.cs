using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HumanResourceProject.Controllers

{
    /*
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;

        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        //[Authorize]
        //[HttpGet]
        //[Route("public")]
        
        //public IActionResult Public()
        //{
        //    var currentUser = GetCurrentUser();
        //    return Ok(currentUser);
        //}

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var users = _userDomain.GetAllUsers();

                if (users != null)
                {
                    return Ok(users);
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

        
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _userDomain.GetUserById(userId);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public LoginDTO GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if (identity != null)
        //    {
        //        var userClaims = identity.Claims;
        //        return new LoginDTO
        //        {
        //            Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //            Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,

        //        };
        //    }
        //    return null;

        //}
    }
    */
}

