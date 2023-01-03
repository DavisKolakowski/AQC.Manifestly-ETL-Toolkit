namespace AQC.Manifestly.Core.Domain.Repository
{
    using AQC.Manifestly.Core.Domain.Contracts.Repository;
    using AQC.Manifestly.Core.Domain.Data;
    using AQC.Manifestly.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositoryCollection : IRepositoryCollection
    {
        private readonly AQCManifestlyDbContext _dbContext;     

        public IRepository<Department> Departments { get; }
        public IRepository<User> Users { get; }
        public IRepository<Workflow> Workflows { get; }
        public IRepository<Run> Runs { get; }
        public IRepository<RunStep> RunSteps { get; }

        public RepositoryCollection(AQCManifestlyDbContext dbContext)
        {
            this._dbContext = dbContext;

            this.Departments = new BaseRepository<Department>(this._dbContext);
            this.Users = new BaseRepository<User>(this._dbContext);
            this.Workflows = new BaseRepository<Workflow>(this._dbContext);
            this.Runs = new BaseRepository<Run>(this._dbContext);
            this.RunSteps = new BaseRepository<RunStep>(this._dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
