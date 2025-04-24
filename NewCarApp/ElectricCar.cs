using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public class ElectricCar : Car, IEnergy
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

        public double EnergyLevel => BatteryLevel;
        public double MaxEnergy => BatteryCapacity;

        public void Refill(double amount)
        {
            BatteryLevel += amount;

            if (BatteryLevel > BatteryCapacity)
            {
                throw new InvalidOperationException("Fejl! Du må ikke overfylde batteriet!");
            }
            Console.ReadLine();
        }

        public bool CanDrive(double km)
        {
            return IsEngineOn && BatteryLevel > (km/KmPerKWh);

        }

        public void UseEnergy (double kilometers)
        {
            BatteryLevel -= kilometers/KmPerKWh;
        }

        public override void UpdateEnergyLevel(double distance)
        {
           UseEnergy(distance);
        }

        public double CalculateConsumption(double distance)
        {
            return distance / KmPerKWh;
        }

       


    }
}
/* public override void Drive(double distance)
        {
            base.Drive(distance);
            BatteryLevel -= distance / KmPerKWh;

            Console.WriteLine($"Der er {BatteryLevel}KWh på batteriet.");
        }

 public double TripPrice(double distance)
        {
            double price = ((distance / KmPerKWh) * 3);
            Console.WriteLine($"Turen koster: {price}kr.");
            return price;
        }

*/