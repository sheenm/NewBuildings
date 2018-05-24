using System.Data.Common;

namespace NewBuildings.Data.Abstract
{
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
