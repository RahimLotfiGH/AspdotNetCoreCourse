using System.Linq;
using System.Threading.Tasks;
using EFCoreTestApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTestApp.AppContexts
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : DomainEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
            _dbSet.Add(entity);

            _unitOfWork.SaveChanges();

            return entity.Id;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);

            if (entityToDelete == null)
                return;

            _dbSet.Remove(entityToDelete);

            _unitOfWork.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete == null)
                return;

            _dbSet.Remove(entityToDelete);

            await _unitOfWork.SaveChangesAsync();

        }

        public void Update(TEntity entityToUpdate)
        {
            try
            {
                var entry = _unitOfWork.Entry(entityToUpdate);

                var attachedEntity = _dbSet.Find(entityToUpdate.Id);
                if (attachedEntity != null)
                {
                    var attachedEntry = _unitOfWork.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entityToUpdate);
                    attachedEntry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Modified;
                }

            }
            catch
            {
                _dbSet.Attach(entityToUpdate);
                _unitOfWork.Entry(entityToUpdate).State = EntityState.Modified;
            }

            _unitOfWork.SaveChanges();
        }

    }
}
