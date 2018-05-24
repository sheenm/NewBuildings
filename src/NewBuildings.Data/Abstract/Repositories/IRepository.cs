using NewBuildings.BusinessLogic.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewBuildings.Data.Abstract.Repositories
{
    public interface IRepository<T> where T : IBusinessObject
    {
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Save(T item);
        Task<bool> Delete(Guid Id);
    }
}
