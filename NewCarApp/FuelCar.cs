using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public class FuelCar : Car
    {
        public double FuelLevel { get; set; }
        public double TankCapacity { get; set; }
        public double KmPerLiter { get; set; }

        public FuelCar(string brand, string model, string licensePlate, double fuelLevel, double tankCapacity, double kMPerLiter) 
                : base(brand, model, licensePlate) 
        {
            FuelLevel = fuelLevel;
            TankCapacity = tankCapacity;
            KmPerLiter = kMPerLiter;
        }

        public void Refuel(double amount)
        {
            FuelLevel += amount;

            if (FuelLevel > TankCapacity)
            {
                throw new InvalidOperationException("Fejl! Du må ikke overfylde tanken!");
            }
        }

        public override bool CanDrive()
        {
            return IsEngineOn && FuelLevel > 0;
        }

        public override void UpdateEnergyLevel(double distance)
        {
            FuelLevel -= distance / KmPerLiter;
        }

        public override double CalculateConsumption(double distance)
        {
            return distance / KmPerLiter;
        }

        public override double TripPrice(double distance)
        {
            double price = ((distance / KmPerLiter) * 14.79);
            Console.WriteLine($"Turen koster: {price}kr.");
            return price;
        }
    }
}
/*
 public override void Drive(double distance)
        {
            base.Drive(distance);
            FuelLevel -= distance / KmPerLiter;

            Console.WriteLine($"Der er {FuelLevel}L i tanken.");
        }
*/