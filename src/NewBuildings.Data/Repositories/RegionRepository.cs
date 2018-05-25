using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;

namespace NewBuildings.Data.Repositories
{
    public class RegionRepository : DapperCrudRepository<Region>, IRegionRepository
    {
        public RegionRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
