using NewBuildings.BusinessLogic.Objects;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace NewBuildings.Data.Abstract.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : IBusinessObject
    {
        protected abstract string DeleteProcedureName { get; }
        protected abstract string GetAllProcedureName { get; }
        protected abstract string GetByIdProcedureName { get; }
        protected abstract string SaveProcedureName { get; }

        private IDbConnectionFactory _connectionFactory;

        protected AbstractRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async virtual Task<bool> Delete(Guid Id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(
                    sql: DeleteProcedureName,
                    param: new { Id },
                    commandType: CommandType.StoredProcedure) != 0;
            }
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(
                    sql: GetAllProcedureName,
                    commandType: CommandType.StoredProcedure);

            }
        }
        public async virtual Task<T> GetById(Guid Id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.QueryFirstAsync<T>(
                        sql: GetByIdProcedureName,
                        param: new { Id },
                        commandType: CommandType.StoredProcedure);
            }
        }

        public async virtual Task<bool> Save(T item)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(
                    sql: SaveProcedureName,
                    param: item,
                    commandType: CommandType.StoredProcedure) != 0;
            }
        }
    }
}
