

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace PersonTransform.Data.Json
{
    public class JsonConverter : IJson
    {
        public TEntity ReadFile<TEntity>(string path)
        {
            var entity = JsonConvert
                .DeserializeObject<TEntity>(
                    File.ReadAllText(path));

            return entity;
        }

        public void WriteFile<TEntity>(string path, TEntity jsonObject)
        {
            using (FileStream fs = File.Open(path, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = JsonSerializer.Create(
                    new JsonSerializerSettings
                    { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                serializer.Serialize(jw, jsonObject);
            }
        }
    }
}
