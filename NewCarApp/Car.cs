using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public abstract class Car : IDrivable
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public bool IsEngineOn { get; set; }
        public double Odometer { get; set; }


        public Car(string brand, string model, string licensePlate) 
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            IsEngineOn = false;
            Odometer = 0;
        }

      
        public void StartEngine()
        {
            if (IsEngineOn)
            {
                throw new InvalidOperationException("Motoren kører allerede.");
            }

            IsEngineOn = true;
        }

        public void StopEngine()
        {
            if (!IsEngineOn)
            {
                throw new InvalidOperationException("Motoren er stoppet.");
            }

            IsEngineOn = false;
        }

        public virtual double Drive(double km)
        {
            if (!CanDrive(km))
            {
                Console.WriteLine("Du kan ikke køre. Tjek niveauet på dit brændstof eller batteri!");
                return 0;
            }

            Odometer += km;
            UpdateEnergyLevel(km);

            if (this is IEnergy energy)
            {
                Console.WriteLine($"Du har kørt {km} km. Ny kilometerstand: {Odometer} km. Der er følgende på batteriet/tanken: {energy.EnergyLevel:F2}/{energy.MaxEnergy}.");
            }
            else
            {
                Console.WriteLine($"Du har kørt {km} km. Ny kilometerstand: {Odometer} km.");
            }

            //Console.WriteLine($"Du har kørt {km} km. Ny kilometerstand: {Odometer} km. Der er følgende på batteriet/tanken {EnergyLevel}");
            return km;
        }

        public virtual bool CanDrive(double km)
        {
            return IsEngineOn;
        }

        public abstract void UpdateEnergyLevel(double distance);

    }
}


/* public virtual void Drive(double distance)
{
    if (IsEngineOn)
    {
        Odometer += (int)distance;
        Console.WriteLine($"\nDu har kørt {distance} km. Ny kilometerstand: {Odometer} km.");
    }
    else
    {
        Console.WriteLine("\nMotoren er ikke tændt. Start bilen før du kan køre.");
    }
}

 public abstract bool CanDrive();
        public abstract void UpdateEnergyLevel(double distance);
        public abstract double CalculateConsumption(double distance);
        public abstract double TripPrice(double distance);


*/