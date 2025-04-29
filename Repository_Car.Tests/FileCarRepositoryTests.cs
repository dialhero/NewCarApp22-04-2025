using System.Linq;
using System.Collections.Generic;
using Repository_Car;

namespace Repository_Car.Tests
{
    using Repository_Car;
    
    [TestClass]
    public class FileCarRepositoryTests
    {
        private readonly string _testFilePath = "test_cars.txt";
        private FileCarRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new FileCarRepository(_testFilePath);
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_testFilePath);
        }


        [TestMethod]
        public void AddCar_SavesCorrectly()
        {
            //Arrange
            var car = new Car("Ford", "Focus", 2018, "Grå", "XY12345", "Benzin");

            //Act
            _repository.AddCar(car);
            var cars = _repository.GetAllCars().ToList();

            //Assert
            Assert.AreEqual(1, cars.Count);
            Assert.AreEqual("XY12345", cars[0].LicensePlate);
            Assert.AreEqual("Ford", cars[0].Make);


        }


    }
}
