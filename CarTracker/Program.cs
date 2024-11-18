using CarTracker.Domain;
using CarTrackeringInfrastructure.Infrastructure;
using CarTracker.Business;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Put the Car Id please :");
        int Plate = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Put the Start date please :");
        DateTime startTime =Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Put the end date please : ");
        DateTime endtime = Convert.ToDateTime(Console.ReadLine());

        IDao dao = new DaoCarPosition();
        CarTracking carTracker = new CarTracking(dao);
        Console.WriteLine($"Postions of the car {Plate} :");
        carTracker.DisplayTracke(Plate, startTime, endtime);
    }
}