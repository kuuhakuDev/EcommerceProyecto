using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Repository
{
    public interface IRepository : IReadEntities, IUnitOfWork,  IDisposable
    {
        IQueryable<TEntity> Load<TEntity>() where TEntity : class;
        void Create<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Detachet<TEntity>(TEntity entity) where TEntity : class;
        IDbContextTransaction BeginTransaction();
    }
}
