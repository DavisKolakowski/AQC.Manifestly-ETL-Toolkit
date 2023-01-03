namespace AQC.Manifestly.Core.Domain.Contracts.Extensions
{
    using AQC.Manifestly.Core.Domain.Entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAQCManifestlyDataMappingExtensions
    {
        Task<List<Department>> MapDataForDepartmentsAsync(IEnumerable<Department> departments);
    }
}
