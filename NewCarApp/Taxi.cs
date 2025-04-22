using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public class Taxi : Car
    {
        public double KmPerLiter { get; set; }
        public double StartPrice { get; set; }
        public double PricePerKM { get; set; }
        public double PricePerMinute { get; set; }
        public bool MeterStarted { get; set; }

        public Taxi(string brand, string model, string licensePlate, double kmPerLiter, double startPrice, double pricePerKM, double pricePerMinute, bool meterStarted)
                : base(brand, model, licensePlate)
        {
            KmPerLiter = kmPerLiter;
            StartPrice = startPrice;
            PricePerKM = pricePerKM;
            PricePerMinute = pricePerMinute;
            MeterStarted = true;
        }

        public void StartMeter()
        {
            MeterStarted = true;
        }

        public void StopMeter()
        {
            MeterStarted = false;
        }

        public double CalculateFare(double distance, double minutes)
        {
            double fare = StartPrice + (distance * PricePerKM) + (minutes * PricePerMinute);
            Console.WriteLine($"Turen koster: {fare}");
            return fare;
        }

        public override bool CanDrive()
        {
            return MeterStarted;
        }

        public override void UpdateEnergyLevel(double distance)
        {
            Console.WriteLine("Her vil den opdatere energiniveauet. ");
        }

        public override double CalculateConsumption(double distance)
        {
            double consumption = distance / 18.3 ;
            return consumption;
        }

        public override double TripPrice(double distance)
        {
            double price = ((distance / KmPerLiter) * 13.79);
            Console.WriteLine($"Turen koster: {price}kr.");
            return price;

            
        }



    }
}
