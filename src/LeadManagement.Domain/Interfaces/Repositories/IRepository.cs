using LeadManagement.Domain.Entities;
using System.Linq.Expressions;

namespace LeadManagement.Domain.Interfaces.Repositories;

public interface IRepository
{
    Task<List<T>> GetAllAsync<T>() where T : Entity;
    IQueryable<T> AsQueryable<T>(Expression<Func<T, bool>> filter = null) where T : Entity;
    Task<T> CreateAsync<T>(T entity) where T : Entity;
    Task<T> UpdateAsync<T>(T entity) where T : Entity;
    Task DeleteAsync<T>(T entity) where T : Entity;
}
