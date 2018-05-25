using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;

namespace NewBuildings.Data.Repositories
{
    public class DapperCrudRepository<T> : IRepository<T> where T : class, IBusinessObject, new()
    {
        protected IDbConnectionFactory _connectionFactory;

        protected DapperCrudRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> Delete(Guid Id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return IsSingleQuerySuccessful(await connection.DeleteAsync(Id));
            }
        }

        public async Task<IEnumerable<T>> GetEnumerable(object constraints)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.GetListAsync<T>(constraints);
            }
        }

        public async Task<IEnumerable<T>> GetEnumerable()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.GetListAsync<T>();
            }
        }

        public async Task<T> GetById(Guid Id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.GetAsync<T>(Id);
            }
        }

        public async Task<bool> Save(T item)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();

                if (GetById(item.Id) == null)
                {
                    return await connection.InsertAsync<Guid>(item) == item.Id;
                }

                return IsSingleQuerySuccessful(await connection.UpdateAsync(item));
            }
        }

        private bool IsSingleQuerySuccessful(int rowsAffected)
        {
            return rowsAffected == 1;
        }
    }
}
