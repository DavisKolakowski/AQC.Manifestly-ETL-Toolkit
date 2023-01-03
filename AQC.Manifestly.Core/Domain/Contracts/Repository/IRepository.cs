namespace AQC.Manifestly.Core.Domain.Contracts.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindWhere(Expression<Func<T, bool>> expression);

        Task<T> FindByIdAsync(int id);

        void Create(T entity);

        void CreateRange(List<T> entities);

        Task CreateAsync(T entity);

        Task CreateRangeAsync(List<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(List<T> entities);

        Task BulkUpsertAsync(List<T> entities);
    }
}
