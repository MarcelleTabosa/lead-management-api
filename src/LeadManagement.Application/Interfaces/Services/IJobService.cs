using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Job;

namespace LeadManagement.Application.Interfaces.Services;

public interface IJobService
{
    Task<Result> GetJobsAsync();
    Task<Result> GetByIdAsync(IdRequest id);
    Task<Result> CreateJobAsync(CreateJobRequest request);
    Task<Result> UpdateJobAsync(IdRequest id, UpdateJobRequest request);
    Task<Result> DeleteJobAsync(IdRequest id);
    Task<Result> GetAllWithRelatedAsync();
}
