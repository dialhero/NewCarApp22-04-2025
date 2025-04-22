using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public abstract class Car
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public bool IsEngineOn { get; set; }
        public int Odometer { get; set; }


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
             
        public abstract bool CanDrive();
        public abstract void UpdateEnergyLevel(double distance);
        public abstract double CalculateConsumption(double distance);
        public abstract double TripPrice(double distance);

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
*/