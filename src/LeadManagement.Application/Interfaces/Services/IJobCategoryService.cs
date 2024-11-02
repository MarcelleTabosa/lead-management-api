using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Interfaces.Services;

public interface IJobCategoryService
{
    Task<Result> GetJobCategoriesAsync();
    Task<Result> GetByIdAsync(IdRequest id);
    Task<Result> CreateJobCategoryAsync(CreateJobCategoryRequest request);
    Task<Result> UpdateJobCategoryAsync(IdRequest id, UpdateJobCategoryRequest request);
    Task<Result> DeleteJobCategoryAsync(IdRequest id);
}
