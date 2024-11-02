using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces.Repositories;
using LeadManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeadManagement.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync<T>() where T : Entity
    {
        return await _context.Set<T>().ToListAsync();
    }
    public IQueryable<T> AsQueryable<T>(Expression<Func<T, bool>> filter = null) where T : Entity
    {
        var query = _context.Set<T>().AsQueryable();

        if (filter != null) query = query.Where(filter);

        return query;
    }

    public async Task<T> CreateAsync<T>(T entity) where T : Entity
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync<T>(T entity) where T : Entity
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync<T>(T entity) where T : Entity
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

}
