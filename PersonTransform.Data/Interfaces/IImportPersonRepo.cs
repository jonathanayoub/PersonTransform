using PersonTransform.Data.Entities;
using System.Collections.Generic;

namespace PersonTransform.Data.Interfaces
{
    public interface IImportPersonRepo
    {
        IList<ImportPerson> GetAll();
    }
}
