namespace AQC.Manifestly.Core.Domain.Data.Configuration
{
    using AQC.Manifestly.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department), "AQC.Manifestly");
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
