using CarTracker.Domain;
using CarTracker.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrackeringInfrastructure.Infrastructure
{
    public class DaoCarPosition : IDao
    {
        private MySqlConnection _con;
        private string _connectionString = "server=localhost;port=3306;user=root;database=vehiculesimulator;Uid=root";

        public DaoCarPosition()
        {
            _con = ConnectionManager.GetInstance(_connectionString).GetConnection();
        }

        public bool IStock(DTOstock Stock)
        {
            string query = "insert into vehiculePosition (matricule,positionX,positionY,time)value(@plate,@positionX,@positionY,@tim)";
            MySqlCommand cmd = new MySqlCommand(query, _con);
            cmd.Parameters.AddWithValue("@matricule", Stock.plate);
            cmd.Parameters.AddWithValue("@positonX", Stock.X);
            cmd.Parameters.AddWithValue("positionY", Stock.Y);
            cmd.Parameters.AddWithValue("time", Stock.Time);
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public List<DTOstock> Retrieve(int plate, DateTime startTime, DateTime endTime)
        {
            string query = "SELECT * FROM vehiculeposition WHERE matricule = @id AND time BETWEEN @startDate AND @endDate";
            MySqlCommand cmd = new MySqlCommand(query, _con);
            cmd.Parameters.AddWithValue("@id", plate);
            cmd.Parameters.AddWithValue("@startDate", startTime);
            cmd.Parameters.AddWithValue("endDate", endTime);

            List<DTOstock> CarPositions = new List<DTOstock>();

            DTOstock positionCar = null;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                positionCar = new DTOstock
                {
                    plate = (int)reader["matricule"],
                    X = (int)reader["positionX"],
                    Y = (int)reader["positionY"],
                    Time = Convert.ToDateTime(reader["time"])
                };
                CarPositions.Add(positionCar);

            }
            return CarPositions;
        }
    }
}


