using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentingWebApp.Repository
{
    public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectByID(int id);
        Task<T> SelectByCompositeKey(int movieId, int userId);
        Task Insert(T entity);
        Task Update(T obj);
        Task Delete(T obj);
    }
}
