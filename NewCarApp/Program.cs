using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace NewCarApp
{
    public class Program
    {

        static Car selectedCar = null;
        
        static void Main(string[] args)
        {
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

                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        Console.Clear();

                        FleetManager fleet = new FleetManager();

                        var fuelCar2 = new FuelCar("Mercedes", "E-Class", "TX11223", 40, 50, 12.3);
                        var fuelTaxi = new Taxi("Mercedes", "E-Class", "TX11223", fuelCar2, 35, 10.2, 5.2);
                        
                        var electricCar2 = new ElectricCar("Tesla", "Model X", "EM123456", 60, 75, 6);
                        var electricTaxi = new Taxi("Tesla", "Model X", "EM123456", electricCar2, 35, 10.2, 5.2);

                        fleet.AddVehicle(new FuelCar("Toyota", "Corolla", "AB12345", 20, 50, 18.3));
                        fleet.AddVehicle(new ElectricCar("Tesla", "Model S", "CD67890", 50, 75, 5));
                        
                        fleet.AddVehicle(fuelTaxi);
                        fleet.AddVehicle(electricTaxi);

                        fleet.DisplayFleetStatus();
                        Console.WriteLine();

                        fleet.StartAllEngines();
                        fleet.DriveAllVehicles(20);

                        Console.WriteLine();
                        fleet.RefillAllVehicles();

                        Console.WriteLine();
                        fleet.DisplayFleetStatus();
                        fleet.StopAllEngines();

                        Console.ReadLine();

                        return;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        Console.Clear();

                        var fuelCar1 = new FuelCar("Mercedes", "E-Class", "TX11223", 43, 50, 12.3);
                        var fuelTaxi1 = new Taxi("Mercedes", "E-Class", "TX11223", fuelCar1, 35, 10.2, 5.2);

                        var electricCar1 = new ElectricCar("Tesla", "Model X", "EM123456", 60, 100, 6);
                        var electricTaxi1 = new Taxi("Tesla", "Model X", "EM123456", electricCar1, 35, 10.2, 5.2);

                        Console.Clear();
                        Console.WriteLine("TEST AF TAXAER\n");

                        Console.WriteLine("Brændstof taxi:");
                        TestTaxi(fuelTaxi1);

                        Console.Clear();
                        Console.WriteLine("El taxi:");
                        TestTaxi(electricTaxi1);

                        break;
                    
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        break;

                    default:
                        return;

                }
            }
        }

        static void TestTaxi(Taxi taxi)
        {
            try
            {
                Console.WriteLine($"\nTest af {taxi.Brand} {taxi.Model} ({taxi.LicensePlate})");

                taxi.StartEngine();
                taxi.StartMeter();

                double km = 10;
                double minutter = 15;

                double kørt = taxi.Drive(km);
                double fare = taxi.CalculateFare(kørt, minutter);

                taxi.StopMeter();
                taxi.StopEngine();

                Console.WriteLine($"\nTuren er slut.");
                Console.WriteLine($"Du kørte {kørt} km og brugte {minutter} minutter.");
                Console.WriteLine($"Pris for turen: {fare:C2}");
                Console.WriteLine($"Resterende energi: {taxi.EnergyLevel:F2}/{taxi.MaxEnergy:F2}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under test: {ex.Message}");
            }

            Console.WriteLine("Tryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        public static void CustomerFare()
        {
            if (selectedCar is Taxi taxi)
            {
                Console.Clear();
                Console.Write("\nHvor lang var turen i km? ");
                double.TryParse(Console.ReadLine(), out double km);

                Console.Write("Hvor mange minutter tog turen? ");
                double.TryParse(Console.ReadLine(), out double minutter);

                taxi.CalculateFare(km, minutter);
                Console.ReadLine() ;
            }
            else
            {
                Console.WriteLine("Valgt bil er ikke en taxi.");
                Console.ReadLine();
            }

            
        }

        static void Drive()
        {
            Console.Clear();
            Console.Write("\nHvor lang en tur kørte du i km? ");
            double.TryParse(Console.ReadLine(), out double km);
            
            selectedCar.UpdateEnergyLevel(km);
            selectedCar.Odometer += (int)km;
            Console.WriteLine($"\nDu har kørt {km} km. Ny kilometerstand: {selectedCar.Odometer} km.");
            Console.ReadLine();

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
                    Console.ReadLine();

                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    selectedCar = new ElectricCar("Tesla", "Model S", "EL12345", 60, 75, 6);
                    Console.WriteLine("\nElbil valgt.");
                    Console.ReadLine();

                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();

                    Console.WriteLine(@"
    | ---------------------------------------------------- |
    |                                                      |
    |          Vælg taxi type:                             |
    |       1. Brændstof                                   |
    |       2. El                                          |
    |                                                      |
    | ---------------------------------------------------- |");

                    var taxiKey = Console.ReadKey().Key;
                    if (taxiKey == ConsoleKey.D1 || taxiKey == ConsoleKey.NumPad1)
                    {
                        var fuelCar = new FuelCar ("Mercedes", "E-Class", "TX11223", 43, 50, 12.3);
                        selectedCar = new Taxi("Mercedes", "E-Class", "TX11223", fuelCar, 35, 10.2, 5.2);
                        Console.WriteLine("Brændstof taxi valgt!");
                    }
                    else if (taxiKey == ConsoleKey.D2 || taxiKey == ConsoleKey.NumPad2)
                    {
                        var electricCar = new ElectricCar("Tesla", "Model X", "EM123456", 60, 75, 6);
                        selectedCar = new Taxi("Tesla", "Model X", "EM123456", electricCar, 35, 10.2, 5.2);
                        Console.WriteLine("El taxi valgt!");
                    }
                    Console.ReadLine();

                    break;

                default:
                    Console.WriteLine("\nUgyldigt valg!");
                    Console.ReadLine();
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
    |                                                      |
    |       8. Test Fleet                                  |
    |       9. Test Taxi                                   |
    |       0. Afslut                                      |
    |                                                      |
    | ---------------------------------------------------- |");
        }
    } 
}

/* 
  selectedCar = new Taxi("Mercedes", "E-Class", "TX11223", 15.3, 49.0, 12.3, 7.5, true);
  Console.WriteLine("\nTaxi valgt.");

// FuelCar fuelCar = new FuelCar("Toyota", "Corolla", "AB12345", 50, 20, 18.3);
            // fuelCar.StartEngine();
            // fuelCar.Drive(100);
            // Console.WriteLine($"FuelCar Odometer: {fuelCar.Odometer}, Fuel left: {fuelCar.FuelLevel}");


*/