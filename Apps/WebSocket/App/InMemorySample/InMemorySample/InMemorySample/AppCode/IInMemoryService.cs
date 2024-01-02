namespace InMemorySample.AppCode
{
    public interface IInMemoryService
    {

        void Add(string key, string value);

        void Delete(string key);

        string Get(string key);

        void DeleteAll();

        bool IsExists(string key);

    }
}
