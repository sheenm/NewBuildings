using NewBuildings.BusinessLogic.Objects;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Abstract.Repositories;

namespace NewBuildings.Data.Repositories
{
    public class FlatRepository : AbstractRepository<Flat>, IFlatRepository
    {
        protected override string DeleteProcedureName => "SITE_DEL_Flat";

        protected override string GetAllProcedureName => "SITE_GET_Flats";

        protected override string GetByIdProcedureName => "SITE_GET_FlatById";

        protected override string SaveProcedureName => "SITE_INUPD_Flat";

        protected FlatRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
