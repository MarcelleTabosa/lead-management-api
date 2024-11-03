using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Lead;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.WebApi.Controllers
{
    [ApiController] 
    [Route("api/lead")] 
    public class LeadController : Controller
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _leadService.GetJobCategoriesAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _leadService.GetByIdAsync(idRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateLeadRequest request)
        {
            var result = await _leadService.CreateLeadAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(CreateCategory), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateLeadRequest request)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _leadService.UpdateLeadAsync(idRequest, request);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var idRequest = new IdRequest { Id = id };

            var result = await _leadService.DeleteLeadAsync(idRequest);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok();
        }
    }
}
