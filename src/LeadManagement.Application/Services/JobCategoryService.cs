using FluentValidation;
using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
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
    private readonly IValidator<IdRequest> _idValidator;

    public JobCategoryService(
        IRepository repository, 
        IValidator<CreateJobCategoryRequest> createJobCategoryValidator,
        IValidator<UpdateJobCategoryRequest> updateJobCategoryValidator,
        IValidator<IdRequest> idValidator)
    {
        _repository = repository;
        _createJobCategoryValidator = createJobCategoryValidator;
        _updateJobCategoryValidator = updateJobCategoryValidator;
        _idValidator = idValidator;
    }

    public async Task<Result> GetJobCategoriesAsync()
    {
        return Result.Success(await _repository.GetAllAsync<JobCategory>());
    }

    public async Task<Result> GetByIdAsync(IdRequest id)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<JobCategory>(x => x.Id == id.Id).SingleOrDefaultAsync();
        if (response == null) return Result.Failure("Category not found.");

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

    public async Task<Result> UpdateJobCategoryAsync(IdRequest id, UpdateJobCategoryRequest request)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (validationResult.IsValid) validationResult = await _updateJobCategoryValidator.ValidateAsync(request);

        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(id);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        var category = (JobCategory) response.Value;

        category.Category = request.Category;

        var result = await _repository.UpdateAsync<JobCategory>(category);

        return Result.Success(result);
    }

    public async Task<Result> DeleteJobCategoryAsync(IdRequest request)
    {
        var validationResult = await _idValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(request);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        await _repository.DeleteAsync<JobCategory>((JobCategory)response.Value);

        return Result.Success();
    }
}
