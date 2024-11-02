using FluentValidation;
using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests.JobCategory;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Application.Services;

public class JobCategoryService : IJobCategoryService
{
    private readonly IRepository _repository;
    private readonly IValidator<CreateJobCategoryRequest> _createJobCategoryValidator;
    private readonly IValidator<UpdateJobCategoryRequest> _updateJobCategoryValidator;
    private readonly IValidator<JobCategoryIdRequest> _jobCategoryIdValidator;

    public JobCategoryService(
        IRepository repository, 
        IValidator<CreateJobCategoryRequest> createJobCategoryValidator,
        IValidator<UpdateJobCategoryRequest> updateJobCategoryValidator,
        IValidator<JobCategoryIdRequest> jobCategoryIdValidator)
    {
        _repository = repository;
        _createJobCategoryValidator = createJobCategoryValidator;
        _updateJobCategoryValidator = updateJobCategoryValidator;
        _jobCategoryIdValidator = jobCategoryIdValidator;
    }

    public async Task<Result> GetJobCategoriesAsync()
    {
        return Result.Success(await _repository.GetAllAsync<JobCategory>());
    }

    public async Task<Result> GetByIdAsync(JobCategoryIdRequest request)
    {
        var validationResult = await _jobCategoryIdValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<JobCategory>(x => x.Id == request.Id).SingleOrDefaultAsync();
        if (response == null) return Result.Failure("Job Category not found.");

        return Result.Success(response);
    }

    public async Task<Result> CreateJobCategoryAsync(CreateJobCategoryRequest request)
    {
        var validationResult = await _createJobCategoryValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<JobCategory>(x => x.Category.ToLower() == request.Category.ToLower()).SingleOrDefaultAsync();
        if (response != null) return Result.Failure("The category already exists.");

        response = await _repository.CreateAsync<JobCategory>(new JobCategory { Category = request.Category, CreatedIn = DateTime.Now });

        return Result.Success(response);
    }

    public async Task<Result> UpdateJobCategoryAsync(JobCategoryIdRequest jobCategoryId, UpdateJobCategoryRequest request)
    {
        var validationResult = await _jobCategoryIdValidator.ValidateAsync(jobCategoryId);
        if (validationResult.IsValid) validationResult = await _updateJobCategoryValidator.ValidateAsync(request);

        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(jobCategoryId);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        var category = (JobCategory) response.Value;

        category.Category = request.Category;
        category.CreatedIn = DateTime.Now;

        var result = await _repository.UpdateAsync<JobCategory>(category);

        return Result.Success(result);
    }

    public async Task<Result> DeleteJobCategoryAsync(JobCategoryIdRequest request)
    {
        var validationResult = await _jobCategoryIdValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(request);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        await _repository.DeleteAsync<JobCategory>((JobCategory)response.Value);

        return Result.Success();
    }
}
