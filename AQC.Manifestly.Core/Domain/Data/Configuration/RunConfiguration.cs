namespace AQC.Manifestly.Core.Domain.Data.Configuration
{
    using AQC.Manifestly.Core.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RunConfiguration : IEntityTypeConfiguration<Run>
    {
        public void Configure(EntityTypeBuilder<Run> builder)
        {
            builder.ToTable(nameof(Run), "AQC.Manifestly");
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
