using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Models;

namespace RepositoryPatternApp.RepoPattern
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: DomainEntity
    {
        private readonly List<TEntity> _domainEntities = new List<TEntity>();
        public void Add(TEntity entity)
        {
            _domainEntities.Add(entity);
        }

        public void Delete(int id)
        {

            foreach (var person in _domainEntities)
            {
                if (person.Id == id)
                    _domainEntities.Remove(person);
            }


        }

        public IList<TEntity> GetAll()
        {
            return _domainEntities.ToList();
        }
    }
}
