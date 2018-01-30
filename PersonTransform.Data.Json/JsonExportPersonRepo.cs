using PersonTransform.Data.Entities;
using PersonTransform.Data.Interfaces;
using System.Collections.Generic;

namespace PersonTransform.Data.Json
{
    public class JsonExportPersonRepo : IExportPersonRepo
    {
        private readonly IConfig _config;
        private readonly IJson _json;

        public JsonExportPersonRepo(IConfig config, IJson json)
        {
            Guard.NotNull(() => config, config);
            Guard.NotNull(() => json, json);
            _config = config;
            _json = json;
        }

        public void Add(IEnumerable<ExportPerson> personsToAdd)
        {
            _json.WriteFile(_config.ExportPath, personsToAdd);
        }
    }
}
