using Domain.Contracts;
using DTO.RoleDTO;
using DTO.RoleDTO1;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    public class RoleController : ControllerBase
    {
        private readonly IRoleDomain roleDomain;

        public Role r = new Role();

        public RoleController(IRoleDomain role1Domain)
        {
           roleDomain = role1Domain;
        }

        [HttpGet("AllRoles")]
        public IActionResult GetAll()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
               var d  = roleDomain.GetAllRoles();
                return Ok(d);
            }
        }

        
        [HttpPost("AddRoles")]
        public IActionResult create(RoleDTO1 role)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                r=roleDomain.CreateRole(role);
                return Ok(r);
            }
        }

        [HttpPost("GetRolesByname")]


        public IActionResult GetByNameRole(String role)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                r = roleDomain.GetByRoleName(role);
                return Ok(r);
            }
        }


        [HttpPost("GetRolesById")]


        public IActionResult GetById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                r = roleDomain.GetById(id);
                return Ok(r);
            }
        }
         
        [HttpPost("RemoveRolesById")]


        public IActionResult RemoveById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            else
            {
               roleDomain.Remove(id);
                return Ok("Deleted");
            }
        }
        [HttpPut("UpdateRoleById")]


        public IActionResult UpdatePermit(RoleDTO role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                roleDomain.Update(role);
                return Ok("updated");
            }
        }
    }
}

