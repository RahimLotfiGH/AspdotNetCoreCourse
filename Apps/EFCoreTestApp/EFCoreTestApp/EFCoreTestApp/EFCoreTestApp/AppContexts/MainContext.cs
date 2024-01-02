using System.Threading.Tasks;
using EFCoreTestApp.Models.Entities;
using EFCoreTestApp.Models.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTestApp.AppContexts
{
    public class MainContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server =.; Database = AppEFCoreDb; Trusted_Connection = True; ");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
        }

        public DbSet<Student> Students { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();

        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
