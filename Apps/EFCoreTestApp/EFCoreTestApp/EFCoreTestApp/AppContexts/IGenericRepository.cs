using System.Linq;
using System.Threading.Tasks;
using EFCoreTestApp.Models.Entities;

namespace EFCoreTestApp.AppContexts
{
    public interface IGenericRepository<TEntity> where TEntity : DomainEntity

    {
        int Add(TEntity entity);

        void Delete(int id);

        void Update(TEntity entityToUpdate);

        IQueryable<TEntity> GetAll();

        Task DeleteAsync(int id);

    }
}
