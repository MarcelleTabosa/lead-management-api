using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Interfaces.Services;

public interface IJobCategoryService
{
    Task<Result> GetJobCategoriesAsync();
    Task<Result> GetByIdAsync(JobCategoryIdRequest id);
    Task<Result> CreateJobCategoryAsync(CreateJobCategoryRequest request);
    Task<Result> UpdateJobCategoryAsync(JobCategoryIdRequest id, UpdateJobCategoryRequest request);
    Task<Result> DeleteJobCategoryAsync(JobCategoryIdRequest id);
}
