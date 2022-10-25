using NUnit.Framework;

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
    }
}