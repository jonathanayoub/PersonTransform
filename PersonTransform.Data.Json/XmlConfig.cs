using System.Configuration;

namespace PersonTransform.Data.Json
{
    public class XmlConfig : IConfig
    {
        public string ImportPath => ConfigurationManager.AppSettings["ImportPath"];

        public string ExportPath => ConfigurationManager.AppSettings["ExportPath"];
    }
}
