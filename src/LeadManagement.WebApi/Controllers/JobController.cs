using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Job;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.WebApi.Controllers
{
    [ApiController] 
    [Route("api/job")] 
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var result = await _jobService.GetJobsAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("relationships")]
        public async Task<IActionResult> GetAllWithRelatedAsync()
        {
            var result = await _jobService.GetAllWithRelatedAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById([FromRoute] int id)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _jobService.GetByIdAsync(idRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobRequest request)
        {
            var result = await _jobService.CreateJobAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(CreateJob), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob([FromRoute] int id, [FromBody] UpdateJobRequest request)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _jobService.UpdateJobAsync(idRequest, request);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _jobService.DeleteJobAsync(idRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok();
        }
    }
}
