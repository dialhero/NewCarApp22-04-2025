using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Car
{
    public interface ITripRepository
    {
        public List<Trip> GetTripsForCar (string regNr);

        public void AddTrip(Trip trip);

        public void DeleteTrip(Trip trip);

    }
}
