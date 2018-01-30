using PersonTransform.Data.Entities;
using System.Collections.Generic;

namespace PersonTransform.Core
{
    public interface IExportPersonListFactory
    {
        IEnumerable<ExportPerson> Create(IEnumerable<ImportPerson> personData);
    }
}
