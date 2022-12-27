using AbstractDependencies.Models;
using System.Linq.Expressions;

namespace AbstractDependencies.Interface.Repositoryes;

public interface IRepository<TEntity, TModel>
    where TEntity : BaseEntityModel
    where TModel : IBusinessModel
{
    public IList<TModel> GetModels(Expression<Func<TEntity, bool>> condition);
    public IList<TModel> GetModels(IQueryable<TEntity> queryDb);
    public IList<TModel> GetModels();
    public Task<IList<TModel>> GetModelsAsync(Expression<Func<TEntity, bool>> condition);
    public Task<IList<TModel>> GetModelsAsync(IQueryable<TEntity> queryDb);
    public Task<IList<TModel>> GetModelsAsync();
    public void Save(TModel models);
    public Task SaveAsync(TModel models);
}
