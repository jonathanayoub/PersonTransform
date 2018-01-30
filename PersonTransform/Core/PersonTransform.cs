using PersonTransform.Data.Interfaces;

namespace PersonTransform.Core
{
    public class PersonTransform : IPersonTransform
    {
        private readonly IImportPersonRepo _importPersonRepo;
        private readonly IExportPersonListFactory _exportPersonFactory;
        private readonly IExportPersonRepo _exportPersonRepo;

        public PersonTransform(IImportPersonRepo importPersonRepo,
            IExportPersonListFactory exportPersonFactory,
            IExportPersonRepo exportPersonRepo)
        {
            Guard.NotNull(() => importPersonRepo, importPersonRepo);
            Guard.NotNull(() => exportPersonFactory, exportPersonFactory);
            Guard.NotNull(() => exportPersonRepo, exportPersonRepo);
            _importPersonRepo = importPersonRepo;
            _exportPersonFactory = exportPersonFactory;
            _exportPersonRepo = exportPersonRepo;
        }

        public void Run()
        {
            var importPersons = _importPersonRepo.GetAll();
            var transformedPersons = _exportPersonFactory.Create(importPersons);
            _exportPersonRepo.Add(transformedPersons);
        }
    }
}