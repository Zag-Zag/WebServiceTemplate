using AbstractDependencies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataBaseEf.Repository;

public abstract class MinRepository
{
    private readonly DbContext _context;

    public MinRepository(DbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    protected DbSet<TEntity> ContextDb<TEntity>()
        where TEntity: BaseEntityModel => _context.Set<TEntity>();

    #region IQueryable
    protected IQueryable<TEntity> GetQueryables<TEntity>()
        where TEntity : BaseEntityModel => ContextDb<TEntity>();

    protected IQueryable<TEntity> GetQueryables<TEntity>(Expression<Func<TEntity, bool>> condition)
        where TEntity : BaseEntityModel => GetQueryables<TEntity>().Where(condition);

    #endregion

    protected void SaveChanges() => _context.SaveChanges();
    protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
