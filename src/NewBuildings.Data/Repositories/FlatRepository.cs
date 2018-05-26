using System.Collections.Generic;
using System.Threading.Tasks;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;
using System.Linq;
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

        public async Task<Flat> GetFullFlatInformation(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                var results =  await connection.QueryAsync<Flat, House, District, Region, Flat>(
                    sql: "SITE_GET_FullFlatInfoById",
                    param: new { Id = id},
                    commandType: CommandType.StoredProcedure,
                    map: (flat, house, district, region) =>
                    {
                        flat.House = house;
                        flat.District = district;
                        flat.Region = region;
                        return flat;
                    });

                return results.FirstOrDefault();
            }
        }
    }
}
