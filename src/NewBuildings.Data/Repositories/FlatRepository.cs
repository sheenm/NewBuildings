using System.Collections.Generic;
using System.Threading.Tasks;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;
using Dapper;
using System.Data;

namespace NewBuildings.Data.Repositories
{
    public class FlatRepository : DapperCrudRepository<Flat>, IFlatRepository
    {
        public FlatRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<Flat>> GetAllFlatsWithHouseInfo()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Flat, House, Flat>(
                    sql: "SITE_GET_AllFlatsWithHouseInfo",
                    commandType: CommandType.StoredProcedure,
                    map: (flat, house) =>
                    {
                        flat.House = house;
                        return flat;
                    });

                //todo: возможно здесь надо добавить splitOn: HouseID
            }
        }
    }
}
