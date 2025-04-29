using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarApp
{
    public class Taxi : Car, IEnergy
    {
        private IEnergy car;
        public double StartPrice { get; set; }
        public double PricePerKM { get; set; }
        public double PricePerMinute { get; set; }
        public bool MeterStarted { get; set; }

        public Taxi(string brand, string model, string licensePlate, IEnergy car, double startPrice, double pricePerKM, double pricePerMinute)
                : base(brand, model, licensePlate)

        {
            this.car = car;
            StartPrice = startPrice;
            PricePerKM = pricePerKM;
            PricePerMinute = pricePerMinute;
            MeterStarted = true;
        }

        public void StartMeter() => MeterStarted = true;
        public void StopMeter() => MeterStarted = false;

        
        public double CalculateFare(double distance, double minutes)
        {
            double fare = StartPrice + (distance * PricePerKM) + (minutes * PricePerMinute);
            Console.WriteLine($"Turen koster: {fare}");
            return fare;
        }

         public override bool CanDrive(double km)
        {
            // Console.WriteLine($"[DEBUG - Taxi] Kan køre? Meter: {MeterStarted}, Motor: {IsEngineOn}, Energi: {car.EnergyLevel}, Krævet: {km}");
            return MeterStarted && IsEngineOn && car.EnergyLevel >= km;
        }
       

        public override void UpdateEnergyLevel(double distance)
        {
            car.UseEnergy(distance);
            
        }

        public override double Drive(double km)
        {
            if (!CanDrive(km))
            {
                Console.WriteLine($"{Brand} {Model} kan ikke køre {km} km pga. lav energi.");
                return 0;
            }

            double driven = base.Drive(km);  // dette vil vise korrekt output, fordi base.Drive logger alt
            car.UseEnergy(km); // vigtigt: Taxi selv opdaterer ikke energi, så vi kalder det manuelt
            return driven;
        }

        public double EnergyLevel => car.EnergyLevel;
        public double MaxEnergy => car.MaxEnergy;

        public void Refill (double amount) => car.Refill(amount);
        public void UseEnergy(double kilometers) => car.UseEnergy(kilometers);


    }
}

/*  public double TripPrice(double distance)
        {
            double price = ((distance / KmPerLiter) * 13.79);
            Console.WriteLine($"Turen koster: {price}kr.");
            return price;           
        }

public double CalculateConsumption(double distance)
        {
            double consumption = distance / 18.3 ;
            return consumption;
        }
*/