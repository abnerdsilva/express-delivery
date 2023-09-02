using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ExpressDelivery.Repository
{
    public class ConnectionDbRepository
    {
        private readonly SqlConnection _con = new SqlConnection();
        
        public ConnectionDbRepository()
        {
            _con.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        public SqlConnection Connect()
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