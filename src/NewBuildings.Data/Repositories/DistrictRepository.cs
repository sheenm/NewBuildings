using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;

namespace NewBuildings.Data.Repositories
{
    public class DistrictRepository : DapperCrudRepository<District>, IDistrictRepository
    {
        protected DistrictRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
