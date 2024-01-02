using System.Collections.Generic;
using RepositoryPatternApp.Models;

namespace RepositoryPatternApp.RepoPattern
{
    public interface IGenericRepository<TEntity> 
        where TEntity: DomainEntity
    {
        void Add(TEntity entity);

        void Delete(int id);

        IList<TEntity> GetAll();

    }

    
}
