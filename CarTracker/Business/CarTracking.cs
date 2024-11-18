using CarTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Business
{
    internal class CarTracking
    {
        IDao _dao;
        public CarTracking(IDao stock)
        {
            this._dao = stock;
        }
        public List<DTOstock> trackeCar(int Plate, DateTime startTime, DateTime endTime)
        {
            return _dao.Retrieve(Plate, startTime, endTime);
        }

        public void DisplayTracke(int Plat, DateTime startTime, DateTime endtime)
        {
            List<DTOstock> carPosition = trackeCar(Plat, startTime, endtime);
            foreach (DTOstock car in carPosition)
            {
                Console.WriteLine($"The car position is in X:{car.X} and Y:{car.Y} at the time of {car.Time}");
            }


        }
    }
}
