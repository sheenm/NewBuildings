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

        public async Task<bool> Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return IsSingleQuerySuccessful(await connection.DeleteAsync<T>(id));
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

        public async Task<T> GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.GetAsync<T>(id);
            }
        }

        public async Task<bool> Save(T item)
        {
            if (Validate(item) == false)
                return false;

            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();

                if (GetById(item.Id) == null)
                {
                    return await connection.InsertAsync<int>(item) == item.Id;
                }

                return IsSingleQuerySuccessful(await connection.UpdateAsync(item));
            }
        }

        private bool IsSingleQuerySuccessful(int rowsAffected)
        {
            return rowsAffected == 1;
        }

        protected virtual bool Validate(T item)
        {
            return true;
        }
    }
}
