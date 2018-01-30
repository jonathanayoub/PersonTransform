using PersonTransform.Data.Entities;
using System.Collections.Generic;

namespace PersonTransform.Data.Interfaces
{
    public interface IExportPersonRepo
    {
        void Add(IEnumerable<ExportPerson> personsToAdd);
    }
}
