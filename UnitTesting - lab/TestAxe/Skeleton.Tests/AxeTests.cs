using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Axe_Loses_Durability_After_Attack()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(1, 1);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void Test_Throws_Exception_When_Axe_Is_Broken()
        {
            var axe = new Axe(1, 0);
            var target = new Dummy(1, 1);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(target));
        }
    }
}