using CarTrackeingDomain.Domain;
using CarTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOstock = CarTrackeingDomain.Domain.DTOstock;
using IDao = CarTrackeingDomain.Domain.IDao;

namespace CarSimulator.Business
{
    internal class CarManagement
    {
        List<Car> Cars;
        IDao stock;
        Mutex mutex = new Mutex();

        public CarManagement(IDao stock)
        {
            this.stock = stock;
            this.Cars = new List<Car>();
        }

        public void InitialiseCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("No Car found !");
            }
            Cars.Add(car);
        }

        public void StartSimulator()
        {
            foreach (var car in Cars)
            {
                Thread t = new Thread(() => StartGPS(car));
                t.Start();
            }
        }
        public void StartGPS(Car car)
        {
            while (true)
            {
                Position position = new Position();
                DTOstock DTOstock = new DTOstock();
                DTOstock.X=position.X;
                DTOstock.Y=position.Y;
                DTOstock.Time=position.DateStamp;
                DTOstock.plate = car.Plate;

                Console.WriteLine($"Car {car.Plate}, x:{position.X}, y:{position.Y}, time:{position.DateStamp}");

                if(mutex.WaitOne())
                {
                    stock.IStock(DTOstock);
                    mutex.ReleaseMutex();
                }
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
