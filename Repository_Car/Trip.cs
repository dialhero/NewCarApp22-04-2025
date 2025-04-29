using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Car
{
    public class Trip
    {
        public string CarRegNr { get; set; }
        public double Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Trip(string carRegNr, double distance, DateTime date, TimeSpan startTime, DateTime endTime)
        {
            CarRegNr = carRegNr;
            Distance = distance;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {  
            return $"{CarRegNr};{Distance};{Date:yyyy-MM-dd};{StartTime};{EndTime:yyyy-MM-ddTHH:mm:ss}"; 
        }

        public static Trip FromString(string input)
        {
            var parts = input.Split(';');
            if (parts.Length != 5)
            {
                throw new FormatException("Input string er ikke i det rigtige format til Trip.");
            }

            return new Trip(
                parts[0],                   //CarRegNr
                double.Parse(parts[1]),     //Distance
                DateTime.Parse(parts[2]),   //Date
                TimeSpan.Parse(parts[3]),   //StartTime
                DateTime.Parse(parts[4])    //EndTime
                );
                
        }

}


}
