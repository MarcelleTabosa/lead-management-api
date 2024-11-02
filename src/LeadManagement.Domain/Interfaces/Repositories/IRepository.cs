using LeadManagement.Domain.Entities;

namespace LeadManagement.Domain.Interfaces.Repositories;

public interface IRepository
{
    Task<List<T>> GetAllAsync<T>() where T : Entity;
    Task<T> CreateAsync<T>(T entity) where T : Entity;
    Task<T> UpdateAsync<T>(T entity) where T : Entity;
    Task DeleteAsync<T>(T entity) where T : Entity;
}
