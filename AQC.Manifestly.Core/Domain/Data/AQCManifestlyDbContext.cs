namespace AQC.Manifestly.Core.Domain.Data
{
    using AQC.Manifestly.Core.Domain.Data.Configuration;
    using AQC.Manifestly.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AQCManifestlyDbContext : DbContext
    {
        public AQCManifestlyDbContext(DbContextOptions<AQCManifestlyDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(0);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Run> Runs { get; set; }

        public DbSet<RunStep> RunSteps { get; set; }

        public DbSet<RunStepComment> RunStepComments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new RunConfiguration());
            modelBuilder.ApplyConfiguration(new RunStepConfiguration());
            modelBuilder.ApplyConfiguration(new RunStepCommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkflowConfiguration());
        }
    }
}
