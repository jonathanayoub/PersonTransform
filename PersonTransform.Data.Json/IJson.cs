namespace PersonTransform.Data.Json
{
    public interface IJson
    {
        TEntity ReadFile<TEntity>(string path);
        void WriteFile<TEntity>(string path, TEntity jsonObject);
    }
}
