
using AbstractDependencies.Interface.Repositoryes;
using AbstractDependencies.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataBaseEf.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Extension;
using System.Linq.Expressions;

namespace Repository;

public abstract class Repository<TEntity, TModel> : BaseRepository<TEntity>, IRepository<TEntity, TModel>
    where TEntity : BaseEntityModel
    where TModel : IBusinessModel
{
    private readonly IMapper _mapper;
    public Repository(DbContext context, IMapper mapper) : base(context) => _mapper = mapper;

    protected IQueryable<TModel> GetQueryableModels() => GetQueryableModels(ContextDb);

    protected IQueryable<TModel> GetQueryableModels(IQueryable<TEntity> queryDb) 
        => queryDb.ProjectTo<TModel>(_mapper.ConfigurationProvider);
    
    protected IQueryable<TModel> GetQueryableModels(Expression<Func<TEntity, bool>> condition) => GetQueryableModels(GetQueryables(condition));

    public IList<TModel> GetModels(Expression<Func<TEntity, bool>> condition) => GetQueryableModels(condition)
        .ExtractList();
    public IList<TModel> GetModels(IQueryable<TEntity> queryDb) => GetQueryableModels(queryDb)
        .ExtractList();
    public IList<TModel> GetModels() => GetQueryableModels()
        .ExtractList();

    public async Task<IList<TModel>> GetModelsAsync(Expression<Func<TEntity, bool>> condition) => await GetQueryableModels(condition)
        .ExtractListAsync();
    public async Task<IList<TModel>> GetModelsAsync(IQueryable<TEntity> queryDb) => await GetQueryableModels(queryDb)
        .ExtractListAsync();
    public async Task<IList<TModel>> GetModelsAsync() => await GetQueryableModels()
        .ExtractListAsync();

    protected TEntity ProjectToEntity(TModel models) => _mapper.Map<TEntity>(models);
    protected TModel ProjectToModel(TEntity models) => _mapper.Map<TModel>(models);

    public virtual void Save(TModel models) => Save(ProjectToEntity(models));
    public virtual async Task SaveAsync(TModel models) => await SaveAsync(ProjectToEntity(models));
}
