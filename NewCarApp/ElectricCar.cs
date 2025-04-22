using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public class ElectricCar : Car
    {
        public double BatteryLevel { get; set; }
        public double BatteryCapacity { get; set; }
        public double KmPerKWh {  get; set; }

        public ElectricCar(string brand, string model, string licensePlate, double batteryLevel, double batteryCapacity, double kMPerKWh) 
                    : base(brand, model, licensePlate)
        {
            BatteryLevel = batteryLevel;
            BatteryCapacity = batteryCapacity;
            KmPerKWh = kMPerKWh;
        }


        public void Charge(double amount)
        {
            BatteryLevel += amount;

            if (BatteryLevel > 0.9*BatteryCapacity)
            {
                throw new InvalidOperationException("Fejl! Du må ikke overfylde batteriet!");
            }
        }

        public override bool CanDrive()
        {
            return IsEngineOn && BatteryLevel > 0;
        }

        public override void UpdateEnergyLevel(double distance)
        {
           BatteryLevel -= distance/KmPerKWh;
        }

        public override double CalculateConsumption(double distance)
        {
            return distance / KmPerKWh;
        }

        public override double TripPrice(double distance)
        {
            double price = ((distance / KmPerKWh) * 3);
            Console.WriteLine($"Turen koster: {price}kr.");
            return price;
        }


    }
}
/* public override void Drive(double distance)
        {
            base.Drive(distance);
            BatteryLevel -= distance / KmPerKWh;

            Console.WriteLine($"Der er {BatteryLevel}KWh på batteriet.");
        }

*/