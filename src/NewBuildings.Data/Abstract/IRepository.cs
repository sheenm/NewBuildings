using NewBuildings.Data.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewBuildings.Data.Abstract
{
    public interface IRepository<T> where T : class, IBusinessObject, new()
    {
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetEnumerable();
        Task<IEnumerable<T>> GetEnumerable(object constraints);
        Task<bool> Save(T item);
        Task<bool> Delete(Guid Id);
    }
}
