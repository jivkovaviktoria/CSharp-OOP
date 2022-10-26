namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void InitTest()
        {
            arena = new Arena();
            warrior = new Warrior("Axel", 10, 100);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(0, arena.Warriors.Count);
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        public void EnrollShouldAddWarriorIfItDoesNotExist()
        {
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorAlreadyExist()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightShouldThrowExceptionIfAttackerOrDefenderNameIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(null, "Axel"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Axel", null));
        }

        [Test]
        public void FightShouldInvokeAttack()
        {
            var target = new Warrior("Lexa", 10, 100);
            arena.Enroll(warrior);
            arena.Enroll(target);

            arena.Fight("Axel", "Lexa");
            Assert.AreEqual(warrior.HP, 90);
            Assert.AreEqual(target.HP, 90);
        }
    }
}
