using System.Linq;
using System.Collections.Generic;
using Repository_Car;

namespace Repository_Car.Tests;

    [TestClass]
    public class FileTripRepositoryTests
    {
        private readonly string _testFilePath = "test_trips.txt";
        private FileTripRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new FileTripRepository(_testFilePath);
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void GetTripsForCar_ReturnsCorrectTrips()
        {
            // Arrange
            var trip1 = new Trip("XY12345", 50.5, DateTime.Today, new TimeSpan(9, 0, 0), DateTime.Today.AddHours(11));
            var trip2 = new Trip("ZZ67890", 80, DateTime.Today, new TimeSpan(10, 0, 0), DateTime.Today.AddHours(12));

            _repository.AddTrip(trip1);
            _repository.AddTrip(trip2);

            // Act
            var trips = _repository.GetTripsForCar("XY12345");

            // Assert
            Assert.AreEqual(1, trips.Count);
            Assert.AreEqual(50.5, trips.First().Distance);
            Assert.AreEqual("XY12345", trips.First().CarRegNr);
        }
    }

