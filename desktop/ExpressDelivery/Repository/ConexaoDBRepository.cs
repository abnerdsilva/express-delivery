using System.Configuration;
using MySqlConnector;

namespace ExpressDelivery.Repository
{
    public class ConnectionDbRepository
    {
        private readonly MySqlConnection _con = new MySqlConnection();
        
        public ConnectionDbRepository()
        {
            _con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        public MySqlConnection Connect()
        {
            if (_con.State == System.Data.ConnectionState.Closed)
            {
                _con.Open();
            }

            return _con;
        }
        
        public void Disconnect()
        {
            if (_con.State == System.Data.ConnectionState.Open)
            {
                _con.Close();
            }
        }
    }
}