using Domain.Contracts;
using DTO.JobDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IJobDomain _jobdomain;

        public JobController(IConfiguration config, IJobDomain jobdomain)
        {
            _config = config;
            _jobdomain = jobdomain;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetEducationById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _jobdomain.GetJobById(userId);


                return Ok(user);


            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        [HttpPost]
        [Route("addJob")]
        public IActionResult AddJob([FromBody] JobDTO job)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _jobdomain.Add(job);


                return Ok(user);


            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        [HttpPut]
        [Route("userId")]
        public IActionResult UpdateEducation([FromBody] JobDTO job)
        {
            try
            {


                _jobdomain.Update(job);
                return Ok("updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }





        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteEducation([FromRoute] Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                _jobdomain.Remove(Id);


                return Ok("update completed");


            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
