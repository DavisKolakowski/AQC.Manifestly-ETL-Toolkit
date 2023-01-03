namespace AQC.Manifestly.Core.Domain.Contracts.Repository
{
    using AQC.Manifestly.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore.Storage;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositoryCollection : IDisposable
    {
        IRepository<Department> Departments { get; }

        IRepository<User> Users { get; }

        IRepository<Workflow> Workflows { get; }

        IRepository<Run> Runs { get; }

        IRepository<RunStep> RunSteps { get; }

        Task<int> SaveAsync();
    }
}
