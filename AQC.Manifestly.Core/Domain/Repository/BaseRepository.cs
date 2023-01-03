namespace AQC.Manifestly.Core.Domain.Repository
{
    using AQC.Manifestly.Core.Domain.Contracts.Repository;
    using AQC.Manifestly.Core.Domain.Data;
    using AQC.Manifestly.Core.Domain.Entities;

    using EFCore.BulkExtensions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Logging;

    using System.Linq.Expressions;

    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected AQCManifestlyDbContext _dbContext { get; set; }

        public BaseRepository(AQCManifestlyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this._dbContext
                    .Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> expression)
        { 
            return this._dbContext
                    .Set<T>()
                        .Where(expression)
                .AsNoTracking();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var entity = await this._dbContext
                    .Set<T>()
                .FindAsync(id);

            return entity!;
        }

        public void Create(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }

        public void CreateRange(List<T> entities)
        {
            this._dbContext.Set<T>().AddRange(entities);
        }

        public async Task CreateAsync(T entity)
        { 
            await this._dbContext.Set<T>().AddAsync(entity);
        }

        public async Task CreateRangeAsync(List<T> entities)
        {
            await this._dbContext.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            this._dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task BulkUpsertAsync(List<T> entities)
        {
            await this._dbContext.BulkInsertOrUpdateAsync(entities, new BulkConfig { IncludeGraph = true, BulkCopyTimeout = 0 });
        }
    }
}