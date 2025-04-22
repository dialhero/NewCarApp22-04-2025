using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace NewCarApp
{
    public class Program
    {
        static Car selectedCar = null;

        static void Main(string[] args)
        {
            // FuelCar fuelCar = new FuelCar("Toyota", "Corolla", "AB12345", 50, 20, 18.3);
            // fuelCar.StartEngine();
            // fuelCar.Drive(100);
            // Console.WriteLine($"FuelCar Odometer: {fuelCar.Odometer}, Fuel left: {fuelCar.FuelLevel}");


            while (true)
            {
                Console.Clear();

                Menu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        ChooseCar();
                        Console.ReadLine();

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Drive();
                        Console.ReadLine();

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CustomerFare();
                        Console.ReadLine();

                        break;

                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        return;

                    default:
                        break;


                }
            }
        }

        public static void CustomerFare()
        {
            if (selectedCar is Taxi taxi)
            {
                Console.Write("\nHvor lang var turen i km? ");
                double.TryParse(Console.ReadLine(), out double km);

                Console.Write("Hvor mange minutter tog turen? ");
                double.TryParse(Console.ReadLine(), out double minutter);

                taxi.CalculateFare(km, minutter);
            }
            else
            {
                Console.WriteLine("Valgt bil er ikke en taxi.");
            }
        }
              

        static void Drive()
        {

            Console.Write("\nHvor lang en tur kørte du i km? ");
            double.TryParse(Console.ReadLine(), out double km);
            
            selectedCar.UpdateEnergyLevel(km);
            selectedCar.Odometer += (int)km;
            Console.WriteLine($"\nDu har kørt {km} km. Ny kilometerstand: {selectedCar.Odometer} km.");
            selectedCar.TripPrice(km);

        }

        static void ChooseCar()
        {
            Console.Clear();
            Console.WriteLine("Vælg køretøj:");
            Console.WriteLine("1. Benzinbil ");
            Console.WriteLine("2. Elbil ");
            Console.WriteLine("3. Taxi ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    selectedCar = new FuelCar("Toyota", "Corolla", "AB12345", 50, 20, 18.3);
                    Console.WriteLine("\nBenzinbil valgt.");
                    
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    selectedCar = new ElectricCar("Tesla", "Model S", "EL12345", 60, 75, 6);
                    Console.WriteLine("\nElbil valgt.");
                    
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    selectedCar = new Taxi("Mercedes", "E-Class", "TX11223", 15.3, 49.0, 12.3, 7.5, true);
                    Console.WriteLine("\nTaxi valgt.");
                    
                    break;

                default:
                    Console.WriteLine("\nUgyldigt valg!");
                    break;
            }
        }
        
        public static void Menu()
        {
            Console.WriteLine(@" 
        | ---------------------------------------------------- |
        |                                                      |
        |       1. Vælg et køretøj                             |
        |       2. Kør en tur                                  |
        |       3. Er du en taxakunde? Beregn pris her!        |
        |       0. Afslut                                      |
        |                                                      |
        | ---------------------------------------------------- |");
        }
    } 
}

