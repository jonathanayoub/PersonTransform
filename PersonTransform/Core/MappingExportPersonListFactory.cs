using PersonTransform.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PersonTransform.Core
{
    public class MappingExportPersonListFactory : IExportPersonListFactory
    {
        private readonly ExportPersonFactory _exportPersonFactory;

        public MappingExportPersonListFactory(ExportPersonFactory exportPersonFactory)
        {
            Guard.NotNull(() => exportPersonFactory, exportPersonFactory);
            _exportPersonFactory = exportPersonFactory;
        }

        public IEnumerable<ExportPerson> Create(IEnumerable<ImportPerson> personData)
        {
            var returnList = new List<ExportPerson>();

            personData.ToList().ForEach(
                p => returnList.Add(_exportPersonFactory.Create(p)));

            return returnList;
        }
    }
}
