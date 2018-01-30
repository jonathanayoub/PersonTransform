using PersonTransform.Data.Entities;
using PersonTransform.Data.Interfaces;
using System.Collections.Generic;

namespace PersonTransform.Data.Json
{
    public class JsonImportPersonRepo : IImportPersonRepo
    {
        private readonly IConfig _config;
        private readonly IJson _json;

        public JsonImportPersonRepo(IConfig config, IJson json)
        {
            Guard.NotNull(() => config, config);
            Guard.NotNull(() => json, json);
            _config = config;
            _json = json;
        }

        public IList<ImportPerson> GetAll()
        {
            var importPath = _config.ImportPath;
            var result = _json.ReadFile<IList<ImportPerson>>(importPath);
            return result;
        }
    }
}
