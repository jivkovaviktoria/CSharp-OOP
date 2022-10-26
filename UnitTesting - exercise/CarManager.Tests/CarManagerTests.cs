namespace CarManager.Tests
{
    using NUnit.Framework;
    using CarManager;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        public Car car;

        [SetUp]
        public void InitTest()
        {
            car = new Car("Ford", "Fiesta", 5.00, 50.00);
        }

        [Test]
        public void ConstructorTest()
        {
            car = new Car("Peugeot", "306", 5.50, 50.50);
            Assert.AreEqual(car.FuelAmount, 0);
            Assert.AreEqual(car.Make, "Peugeot");
            Assert.AreEqual(car.Model, "306");
            Assert.AreEqual(car.FuelConsumption, 5.50);
            Assert.AreEqual(car.FuelCapacity, 50.50);
        }

        [Test]
        public void MakeShouldThrowExceptionIfItIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "Fiesta", 5, 50));
        }

        [Test]
        public void MakeShouldThrowExceptionIfItIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "Fiesta", 5, 50));
        }

        [Test]
        public void ModelShouldThrowExceptionIfItIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", null, 5, 50));
        }

        [Test]
        public void ModelShouldThrowExceptionIfItIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "", 5, 50));
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfValueIsZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fiesta", 0, 50));
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fiesta", -1, 50));
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfValueIsZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fiesta", 5, 0));
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fiesta", 5, -1));
        }

        [Test]
        public void RefuelShouldThrowExceptionIfFuelIsZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
        }

        [Test]
        public void RefuelShouldFillToTheCapacityIfFuelIsMoreThanIt()
        {
            car.Refuel(51);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [Test]
        public void RefuelShouldIncreaseFuelAmountWithGivenFuel()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowExceptionIfFuelIsNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void DriveShouldDecreaseFuelAmount()
        {
            car.Refuel(0.5);
            car.Drive(10);
            Assert.AreEqual(0, car.FuelAmount);
        }
    }
}