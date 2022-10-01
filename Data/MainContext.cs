using Data.Models.DataBase;
using Data.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data
{
    public class MainContext : TiendaOnlineContext, IRepository
    {
        public MainContext(DbContextOptions<TiendaOnlineContext> options)
            : base(options)
        {
        }
        public IQueryable<TEntity> Load<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            if (Entry(entity).State != EntityState.Added)
                Set<TEntity>().Add(entity);
        }

        public new void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (Entry(entity).State != EntityState.Modified)
                Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (Entry(entity).State != EntityState.Deleted)
                Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<TEntity> LoadAsNoTracking<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking();
        }
        public void Detachet<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Detached;
        }
        public IDbContextTransaction BeginTransaction() => Database.BeginTransaction();

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
    }
}