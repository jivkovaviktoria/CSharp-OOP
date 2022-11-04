using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void InitTest()
        {
            athlete = new Athlete("x");
            gym = new Gym("x", 2);
        }

        //Athlete tests
        [Test]
        public void TestAthleteConstructor()
        {
            Assert.AreEqual("x", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        //Gym tests

        [Test]
        public void TestGymConstructor()
        {
            Assert.AreEqual("x", gym.Name);
            Assert.AreEqual(2, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void NameShouldThrowExceptionIfItIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Gym("", 1));
        }

        [Test]
        public void CapacityShouldThrowExceptionIfItIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("x", -1));
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void AddAThleteShouldThrowExceptionIfGymIsFull()
        {
            gym = new Gym("x", 0);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void AddAthleteShouldAddAthlete()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionIfTheAthleteDontExist()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("x"));
        }

        [Test]
        public void RemoveAthleteShouldRemoveAthlete()
        {
            gym.AddAthlete(new Athlete("a"));
            gym.AddAthlete(new Athlete("b"));

            Assert.AreEqual(2, gym.Count);

            gym.RemoveAthlete("a");

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionIfTheAthleteDontExist()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("x"));
        }

        [Test]
        public void InjureAthleteShouldInjureAthlete()
        {
            gym.AddAthlete(athlete);
            gym.InjureAthlete("x");

            Assert.AreEqual(true, athlete.IsInjured);
        }

        [Test]
        public void InjureAthleteShouldReturnInjuredAthlete()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(athlete, gym.InjureAthlete("x"));
        }

        [Test]
        public void TestReport()
        {
            gym.AddAthlete(athlete);
            var result = $"Active athletes at {gym.Name}: {athlete.FullName}";

            Assert.AreEqual(result, gym.Report());
        }
    }
}
