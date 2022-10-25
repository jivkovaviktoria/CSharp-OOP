using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_Dummy_Loses_Health_If_Attacked()
        {
            var dummy = new Dummy(10, 10);
            dummy.TakeAttack(9);

            Assert.AreEqual(1, dummy.Health);
        }

        [Test]
        public void Test_Dead_Dummy_Throws_Exception_If_Attacked()
        {
            var dummy = new Dummy(0, 0);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void Test_Dead_Dummy_Can_Give_XP()
        {
            var dummy = new Dummy(0, 1);
            Assert.AreEqual(1, dummy.GiveExperience());
        }

        [Test]
        public void Test_Alive_Dummy_Cant_Give_XP()
        {
            var dummy = new Dummy(1, 1);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}