using Domain.Contracts;
using DTO.ProjectDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectDomain _projectDomain;

        public ProjectController(IProjectDomain projectDomain)
        {
            _projectDomain = projectDomain;
        }


        [HttpPost]
        [Route("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var users = _projectDomain.GetAllProjects();
                return (users != null) ? Ok(users) : NotFound();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult GetProjectByName([FromBody] string name)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var project = _projectDomain.GetProjectByName(name);
                return (project != null) ? Ok(project) : NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProjectDTO project)
        {
            if (!ModelState.IsValid || project == null)
            {
                return BadRequest();
            }
            else
            {
                _projectDomain.CreateProject(project);
                return Ok();
            }
        }


        [HttpDelete]
        [Route("Remove")]
        public IActionResult Remove([FromBody] Guid id)
        {
            var project = _projectDomain.GetProjectById(id);
            if (project == null)
            {
                return BadRequest("Project with this id does not exist.");
            }
            else
            {
                _projectDomain.Remove(id);
                return Ok();
            }
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] ProjectDTO project)
        {

            if (project == null)
            {
                return BadRequest("Project does not exist.");
            }
            else
            {
                _projectDomain.Update(project);
                return Ok();
            }
        }
    }
}
