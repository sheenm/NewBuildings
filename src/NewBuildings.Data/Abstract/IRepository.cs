using NewBuildings.Data.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewBuildings.Data.Abstract
{
    public interface IRepository<T> where T : class, IBusinessObject, new()
    {
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetEnumerable();
        Task<IEnumerable<T>> GetEnumerable(object constraints);
        Task<bool> Save(T item);
        Task<bool> Delete(int Id);
    }
}
