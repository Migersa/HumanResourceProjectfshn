using Domain.Contracts;
using DTO.JobDTO;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Board Member")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var jobs = _jobdomain.GetAllJobs();

                if (jobs != null)
                {
                    return Ok(jobs);
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

        //[HttpGet]
        //[Route("{userId}")]
        //public IActionResult GetEducationById([FromRoute] Guid userId)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest();
        //        var user = _jobdomain.GetJobById(userId);


        //        return Ok(user);


        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}


        [HttpPost]
        [Authorize]
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
        
        public IActionResult UpdateJob([FromBody] JobDTO job)
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
        public IActionResult DeleteJob([FromRoute] Guid Id)
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
