using System;
using NUnit.Framework.Internal;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void InitTest()
        {
            present = new Present("x", 1);
            bag = new Bag();
        }

        //Present tests

        [Test]
        public void TestPresentConstructor()
        {
            Assert.AreEqual(present.Name, "x");
            Assert.AreEqual(present.Magic, 1);
        }

        //Bag tests

        [Test]
        public void CreateShouldWorkCorrectly()
        {
            bag.Create(present);
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentAlreadyExist()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void GetPresentsShouldWorkCorrectly()
        {
            bag.Create(present);
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void CreateShouldReturnCorrectMessage()
        {
            Assert.AreEqual("Successfully added present x.", bag.Create(present));
        }

        [Test]
        public void GetPresentsShouldReturnEmptyCollection()
        {
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void GetPresentShouldWorkCorrectly()
        {
            bag.Create(present);
            Assert.AreEqual(present, bag.GetPresent("x"));
        }

        [Test]
        public void GetPresentShouldReturnNull()
        {
            Assert.AreEqual(null, bag.GetPresent("x"));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrectly()
        {
            var expected = new Present("x2", 0.1);
            bag.Create(present);
            bag.Create(expected);
            
            Assert.AreEqual(expected, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            bag.Create(new Present("a", 1));
            bag.Create(new Present("b", 2));
            bag.Create(present);
            
            Assert.AreEqual(3, bag.GetPresents().Count);

            bag.Remove(present);
            
            Assert.AreEqual(2, bag.GetPresents().Count);
        }
    }
}