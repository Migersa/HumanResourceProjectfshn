using Domain.Contracts;
using DTO.PermitDTO;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    public class PermitController : ControllerBase
    {
        private readonly IPermitDomain permitDomain;

        public Permit p = new Permit();


        public PermitController(IPermitDomain permit1Domain)
        {
            permitDomain = permit1Domain;
        }


        [HttpGet("AllPermits")]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                var d = permitDomain.GetAllPermit();
                return Ok(d);
            }
        }


        [HttpPost("AddPermits")]
        public IActionResult Create(PermitDTO permit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                p = permitDomain.CreatePermit(permit);
                return Ok(p);
            }
        }


        [HttpPost("GetPermitById")]
        public IActionResult GetById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                p = permitDomain.GetById(id);
                return Ok(p);
            }
        }


        [HttpPost("RemovePermitById")]
        public IActionResult RemoveById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                permitDomain.Remove(id);
                return Ok("Deleted");
            }
        }


        [HttpPut("UpdatePermitById")]
        public IActionResult UpdatePermit(PermitDTO1 permit)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                permitDomain.Update(permit);
                return Ok("updated");
            }
        }
    }
}
