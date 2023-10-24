using Domain.Contracts;
using DTO.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDomain _userDomain;

        public EmployeeController(IEmployeeDomain userDomain)
        {
            _userDomain = userDomain;
        }

      
        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                var users = _userDomain.GetAllUsers();

                if (users != null)
                    return Ok(users);
                else
                    return NotFound();
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



        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<EmployeeDTO>> Register(EmployeeDTO request)
        {
            _userDomain.Create(request);
            return Ok(request);
        }


        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] EmployeeDTO1 employee)
        {
            var employeeToUpdate = _userDomain.GetUserById(employee.Id);

            if (employee == null || employeeToUpdate == null)
                return BadRequest("Project does not exist.");
            else
            {
                _userDomain.Update(employee);
                return Ok();
            }
        }
    }
}
