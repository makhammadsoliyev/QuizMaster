using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Contexts;
using QuizMaster.Domain.Commons;
using System.Linq.Expressions;

namespace QuizMaster.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DbSet<TEntity> set;
    private readonly AppDbContext context;

    public Repository(AppDbContext context)
    {
        this.context = context;
        this.set = context.Set<TEntity>();
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
        => (await set.AddAsync(entity)).Entity;

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        return await Task.FromResult(set.Update(entity).Entity);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsDeleted = true;
        return await Task.FromResult(set.Update(entity).Entity);
    }

    public async Task<TEntity> DropAsync(TEntity entity)
        => await Task.FromResult(set.Remove(entity).Entity);

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression,
                                    string[] includes = null)
    {
        var query = set.Where(expression);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null,
                                         string[] includes = null,
                                         bool isTracking = true)
    {
        var query = expression is null ? set : set.Where(expression);
        if (!isTracking)
            query.AsNoTracking();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async Task<bool> SaveAsync()
        => await context.SaveChangesAsync() >= 0;
}
