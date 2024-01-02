
using System.Collections.Generic;

namespace InMemorySample.AppCode
{
    public class InMemoryService : IInMemoryService
    {

        private readonly Dictionary<string, string> _dictionary;

        public InMemoryService()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            if (key   == null   ||
                value == null ||
                IsExists(key)) return;

            _dictionary.Add(key, value);
        }

        public void Delete(string key)
        {
            _dictionary.Remove(key);
        }

        public void DeleteAll()
        {
            _dictionary.Clear();
        }

        public string Get(string key)
        {
            if (!IsExists(key)) return string.Empty;

            return _dictionary
                    .GetValueOrDefault(key);

        }

        public bool IsExists(string key)
        {
            return _dictionary.ContainsKey(key);
        }
    }
}
