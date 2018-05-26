using NewBuildings.Data.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewBuildings.Data.Abstract
{
    public interface IFlatRepository : IRepository<Flat>
    {
        Task<IEnumerable<Flat>> GetAllFlatsWithHouseInfo();

        Task<Flat> GetFullFlatInformation(int id);
    }
}
