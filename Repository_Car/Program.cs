using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Car
{
    internal class Program //Hjælp fra ChatGPT fordi du er en optimist! x(
    {
        static void Main(string[] args)
        {
            string carFilePath = "cars.txt";
            string tripFilePath = "trips.txt";

            var carRepository = new FileCarRepository(carFilePath);
            var tripRepository = new FileTripRepository(tripFilePath);

            // Test: Tilføj en bil
            AddNewCar(carRepository);

            // Test: Hent alle biler
            ListAllCars(carRepository);

            // Test: Tilføj en tur
            AddNewTrip(tripRepository);

            // Test: Find ture for bil
            ListTripsForCar(tripRepository);

            Console.ReadLine();
        }

        static void AddNewCar(ICarRepository carRepository)
        {
            var car = new Car("Tesla", "Model 3", 2021, "Rød", "AB12345", "El");
            try
            {
                carRepository.AddCar(car);
                Console.WriteLine("Bil tilføjet!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved tilføjelse af bil: {ex.Message}");
            }
        }

        static void ListAllCars(ICarRepository carRepository)
        {
            Console.WriteLine("\nAlle biler:");
            foreach (var car in carRepository.GetAllCars())
            {
                Console.WriteLine($"{car.Make} {car.Model} ({car.LicensePlate})");
            }
        }

        static void AddNewTrip(ITripRepository tripRepository)
        {
            var trip = new Trip("AB12345", 120.5, DateTime.Today, new TimeSpan(8, 0, 0), DateTime.Today.AddHours(10));
            tripRepository.AddTrip(trip);
            Console.WriteLine("\nTur tilføjet!");
        }

        static void ListTripsForCar(ITripRepository tripRepository)
        {
            Console.WriteLine("\nTure for bil AB12345:");
            var trips = tripRepository.GetTripsForCar("AB12345");
            foreach (var trip in trips)
            {
                Console.WriteLine($"Dato: {trip.Date.ToShortDateString()}, Distance: {trip.Distance} km");
            }
        }

        
    }
}
