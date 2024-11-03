using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Lead;

namespace LeadManagement.Application.Interfaces.Services;

public interface ILeadService
{
    Task<Result> GetJobCategoriesAsync();
    Task<Result> GetByIdAsync(IdRequest id);
    Task<Result> CreateLeadAsync(CreateLeadRequest request);
    Task<Result> UpdateLeadAsync(IdRequest id, UpdateLeadRequest request);
    Task<Result> DeleteLeadAsync(IdRequest id);
}
