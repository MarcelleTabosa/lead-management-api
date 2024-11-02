using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models.Requests.JobCategory;
using LeadManagement.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.WebApi.Controllers
{
    [ApiController] 
    [Route("api/job-category")] 
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;

        public JobCategoryController(IJobCategoryService jobCategoryService)
        {
            _jobCategoryService = jobCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _jobCategoryService.GetJobCategoriesAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var jobCategoryIdRequest = new JobCategoryIdRequest { Id = id };

            var result = await _jobCategoryService.GetByIdAsync(jobCategoryIdRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateJobCategoryRequest request)
        {
            var result = await _jobCategoryService.CreateJobCategoryAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(CreateCategory), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateJobCategoryRequest request)
        {
            var jobCategoryIdRequest = new JobCategoryIdRequest { Id = id };

            var result = await _jobCategoryService.UpdateJobCategoryAsync(jobCategoryIdRequest, request);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var jobCategoryIdRequest = new JobCategoryIdRequest { Id = id };

            var result = await _jobCategoryService.DeleteJobCategoryAsync(jobCategoryIdRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok();
        }
    }
}
