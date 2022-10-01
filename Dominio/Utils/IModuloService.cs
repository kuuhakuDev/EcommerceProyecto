using System.Linq.Expressions;

namespace Dominio.Utils
{
    public interface IModuloService<TModel> : IDisposable where TModel : class
    {
        Task<TModel> Insert(TModel entry);
        Task<TModel> Update(TModel entry);
        Task<TModel> Delete(TModel entry);
        IQueryable<TModel> GetData(Expression<Func<TModel, bool>> exp);
        IQueryable<TModel> GetData();
    }
}
