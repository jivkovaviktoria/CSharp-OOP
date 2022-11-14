using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;
            
            [SetUp]
            public void InitTest()
            {
                car = new Car("Fiesta", 1);
                garage = new Garage("Ford", 1);
            }
            
            //Car tests
            
            [Test]
            public void TestCarConstructor()
            {
                Assert.AreEqual("Fiesta", car.CarModel);
                Assert.AreEqual(1, car.NumberOfIssues);
            }

            [Test]
            public void CarIsFixedShouldReturnFalseIfNumberOfIssuesIsOver1()
            {
                Assert.AreEqual(false, car.IsFixed);
            }
            
            //Garage tests

            [Test]
            public void TestGarageConstructor()
            {
                Assert.AreEqual("Ford", garage.Name);
                Assert.AreEqual(1, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void NameShouldThrowExceptionIfItIsNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 1));
                Assert.Throws<ArgumentNullException>(() => new Garage("", 1));
            }

            [Test]
            public void MechanicsAvailableShouldThrowExceptionIfItIsZeroOrBelow()
            {
                Assert.Throws<ArgumentException>(() => new Garage("x", 0));
                Assert.Throws<ArgumentException>(() => new Garage("x", -1));
            }

            [Test]
            public void AddCatShouldAddCar()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }
            
            [Test]
            public void AddCarShouldThrowExceptionIfThereAreNoFreeMechanics()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("x", 1)));
            }

            [Test]
            public void FixCarShouldFixCar()
            {
                garage.AddCar(car);
                garage.FixCar("Fiesta");
                
                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void FixCarShouldThrowExceptionIfTheCarDoesntExist()
            {
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Clio"));
            }

            [Test]
            public void RemoveFixedCarsShouldRemoveFixedCars()
            {
                garage = new Garage("Ford", 2);
                garage.AddCar(car);
                garage.AddCar(new Car("Clio", 1));
                garage.FixCar("Fiesta");

                garage.RemoveFixedCar();
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void RemoveCarsShouldThrowExceptionIfThereArentFixedCars()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }

            [Test]
            public void TestReport()
            {
                //"There are {reportCars.Count} which are not fixed: {carsNames}."
                garage.AddCar(car);
                Assert.AreEqual("There are 1 which are not fixed: Fiesta.", garage.Report());
            }
        }
    }
}