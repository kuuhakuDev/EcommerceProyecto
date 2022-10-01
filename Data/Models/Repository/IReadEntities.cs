using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Repository
{
    public interface IReadEntities
    {
        IQueryable<TEntity> LoadAsNoTracking<TEntity>() where TEntity : class;
    }
}
