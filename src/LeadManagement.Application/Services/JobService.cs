using FluentValidation;
using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Job;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Application.Services;

public class JobService : IJobService
{
    private readonly IRepository _repository;
    private readonly IValidator<CreateJobRequest> _createJobValidator;
    private readonly IValidator<UpdateJobRequest> _updateJobValidator;
    private readonly IValidator<IdRequest> _idValidator;

    public JobService(
        IRepository repository,
        IValidator<CreateJobRequest> createJobValidator,
        IValidator<UpdateJobRequest> updateJobValidator,
        IValidator<IdRequest> idValidator)
    {
        _repository = repository;
        _createJobValidator = createJobValidator;
        _updateJobValidator = updateJobValidator;
        _idValidator = idValidator;
    }

    public async Task<Result> GetJobsAsync()
    {
        return Result.Success(await _repository.GetAllAsync<Job>());
    }

    public async Task<Result> GetAllWithRelatedAsync()
    {
        var result = await _repository.GetAllWithRelatedAsync<Job>(
            j => j.JobCategory,
            j => j.Lead
        );

        return Result.Success(result);
    }

    public async Task<Result> GetByIdAsync(IdRequest id)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<Job>(x => x.Id == id.Id).SingleOrDefaultAsync();
        if (response == null) return Result.Failure("Job not found.");

        return Result.Success(response);
    }

    public async Task<Result> CreateJobAsync(CreateJobRequest request)
    {
        var validationResult = await _createJobValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<Job>(
            x => x.Description.ToLower() == request.Description.ToLower() &&
            x.Suburb.ToLower() == request.Suburb.ToLower() &&
            x.Price == request.Price).SingleOrDefaultAsync();
        if (response != null) return Result.Failure("The job already exists.");

        response = await _repository.CreateAsync<Job>(new Job
        {
            Description = request.Description,
            CreatedIn = DateTime.Now,
            Suburb = request.Suburb,
            Price = request.Price,
            JobCategoryId = request.JobCategoryId,
            LeadId = request.LeadId,
        });

        return Result.Success(response);
    }

    public async Task<Result> UpdateJobAsync(IdRequest id, UpdateJobRequest request)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (validationResult.IsValid) validationResult = await _updateJobValidator.ValidateAsync(request);

        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(id);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        var job = (Job)response.Value;

        job.Description = request.Description;
        job.Suburb = request.Suburb;
        job.Price = request.Price;
        job.JobCategoryId = request.JobCategoryId;
        job.Accepted = request.Accepted;

        var result = await _repository.UpdateAsync<Job>(job);

        return Result.Success(result);
    }

    public async Task<Result> DeleteJobAsync(IdRequest id)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(id);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        await _repository.DeleteAsync<Job>((Job)response.Value);

        return Result.Success();
    }

}
