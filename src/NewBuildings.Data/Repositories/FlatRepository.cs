using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;

namespace NewBuildings.Data.Repositories
{
    public class FlatRepository : DapperCrudRepository<Flat>, IFlatRepository
    {
        protected FlatRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
