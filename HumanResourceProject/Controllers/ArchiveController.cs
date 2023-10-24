using Domain.Contracts;
using DTO.ArchiveDTO;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    public class ArchiveController : ControllerBase
    {
        private readonly IArchiveDomain archiveDomain;

        public Archive r = new Archive();


        public ArchiveController(IArchiveDomain archive1Domain)
        {
            archiveDomain = archive1Domain;
        }

        
        [HttpGet("AllArchives")]
        public IActionResult GetAll()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var d = archiveDomain.GetAllArchives();
                return Ok(d);
            }
        }


        [HttpPost("AddArchive")]
        public IActionResult create(ArchiveDTO archive)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                r = archiveDomain.CreateArchive(archive);
                return Ok(r);
            }
        }

        
        [HttpPost("GetArchiveById")]
        public IActionResult GetById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                r = archiveDomain.GetById(id);
                return Ok(r);
            }
        }


        [HttpPost("RemoveArchiveById")]
        public IActionResult RemoveById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                archiveDomain.Remove(id);
                return Ok("Deleted");
            }
        }


        [HttpPut("UpdateArchiveById")]
        public IActionResult UpdateArchive(ArchiveDTO1 archive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                archiveDomain.Update(archive);
                return Ok("updated");
            }
        }
    }
}
