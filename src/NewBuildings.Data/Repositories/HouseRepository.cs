using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;

namespace NewBuildings.Data.Repositories
{
    public class HouseRepository : DapperCrudRepository<House>, IHouseRepository
    {
        protected HouseRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
