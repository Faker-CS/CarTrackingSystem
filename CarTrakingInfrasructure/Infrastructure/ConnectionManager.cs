using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrackeringInfrastructure.Infrastructure
{
    public class ConnectionManager
    {
        public static ConnectionManager _instance;
        public MySqlConnection _con;

        public ConnectionManager(String connectionString)
        {
            _con = new MySqlConnection(connectionString);
            _con.Open();
        }

        public static ConnectionManager GetInstance(String connectionString)
        {
            if (_instance == null)
            {
                _instance = new ConnectionManager(connectionString);

            }

            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return _con;
        }

    }
}
