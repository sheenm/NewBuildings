using System.Threading.Tasks;
using NewBuildings.Data.Abstract;

namespace NewBuildings.BootstrapApp
{
    public class AppBootstraper
    {
        private IDbConnectionFactory _connectionFactory;

        public AppBootstraper(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Bootstrap()
        {
            var databaseBootstraper = new DatabaseBootstraper(_connectionFactory);
            databaseBootstraper.Bootstrap();
        }
    }
}
