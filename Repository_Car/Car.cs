using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Car
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string FuelType { get; set; }
        public List<Trip> Trips { get; set; }

        public Car(string make, string model, int year, string color, string licensePlate, string fuelType)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            LicensePlate = licensePlate;
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{Make};{Model};{Year};{Color};{LicensePlate};{FuelType}";
        }

        public static Car FromString(string input)
        {
            var parts = input.Split(';');
            if (parts.Length != 6)
            {
                throw new FormatException("Input string er ikke i korrekt format til Car.");
            }

            return new Car(
                parts[0],                //Make
                parts[1],               //Model
                int.Parse(parts[2]),   //Year
                parts[3],             //Color
                parts[4],            //LicensePlate
                parts[5]            //FuelType
                );
        }
    }
}
