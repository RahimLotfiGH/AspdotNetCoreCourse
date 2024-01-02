using System.Collections.Generic;
using WebApplication_01.AppCode.Contracts;

namespace WebApplication_01.AppCode.Services
{
    public class InMemoryUserAccessService : IInMemoryUserAccessService
    {
        private readonly Dictionary<long, int[]> _dictionary;

        public InMemoryUserAccessService()
        {
            _dictionary = new Dictionary<long, int[]>();
        }

        public void Add(long userId, int[] userAccess)
        {
            if (IsExists(userId)) Delete(userId);

            _dictionary.Add(userId, userAccess);
        }

        public void Delete(long userId)
        {
            _dictionary.Remove(userId);
        }

        public bool IsExists(long userId)
        {
            return _dictionary
                       .ContainsKey(userId);
        }

        public int[] Get(long userId)
        {
            return _dictionary
                      .GetValueOrDefault(userId);
        }
    }
}
