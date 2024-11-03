using FluentValidation;
using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Models;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Lead;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Application.Services;

public class LeadService : ILeadService
{
    private readonly IRepository _repository;
    private readonly IValidator<CreateLeadRequest> _createLeadValidator;
    private readonly IValidator<UpdateLeadRequest> _updateLeadValidator;
    private readonly IValidator<IdRequest> _idValidator;

    public LeadService(
        IRepository repository, 
        IValidator<CreateLeadRequest> createLeadValidator,
        IValidator<UpdateLeadRequest> updateLeadValidator,
        IValidator<IdRequest> idValidator)
    {
        _repository = repository;
        _createLeadValidator = createLeadValidator;
        _updateLeadValidator = updateLeadValidator;
        _idValidator = idValidator;
    }

    public async Task<Result> GetJobCategoriesAsync()
    {
        return Result.Success(await _repository.GetAllAsync<Lead>());
    }

    public async Task<Result> GetByIdAsync(IdRequest id)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<Lead>(x => x.Id == id.Id).SingleOrDefaultAsync();
        if (response == null) return Result.Failure("Category not found.");

        return Result.Success(response);
    }

    public async Task<Result> CreateLeadAsync(CreateLeadRequest request)
    {
        var validationResult = await _createLeadValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await _repository.AsQueryable<Lead>(
            x => x.Name.ToLower() == request.Name.ToLower() &&
            x.Email.ToLower() == request.Email.ToLower() &&
            x.PhoneNumber.ToLower() == request.PhoneNumber.ToLower()).SingleOrDefaultAsync();
        if (response != null) return Result.Failure("The lead already exists.");

        response = await _repository.CreateAsync<Lead>(new Lead { Name = request.Name, Email = request.Email, PhoneNumber = request.PhoneNumber, CreatedIn = DateTime.Now });

        return Result.Success(response);
    }

    public async Task<Result> UpdateLeadAsync(IdRequest id, UpdateLeadRequest request)
    {
        var validationResult = await _idValidator.ValidateAsync(id);
        if (validationResult.IsValid) validationResult = await _updateLeadValidator.ValidateAsync(request);

        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(id);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        var lead = (Lead) response.Value;

        lead.Name = request.Name;
        lead.Email = request.Email;
        lead.PhoneNumber = request.PhoneNumber;

        var result = await _repository.UpdateAsync<Lead>(lead);

        return Result.Success(result);
    }

    public async Task<Result> DeleteLeadAsync(IdRequest request)
    {
        var validationResult = await _idValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return Result.Failure(validationResult.Errors.First().ErrorMessage);

        var response = await GetByIdAsync(request);
        if (!response.IsSuccess) return Result.Failure(response.Error);

        await _repository.DeleteAsync<Lead>((Lead)response.Value);

        return Result.Success();
    }
}
