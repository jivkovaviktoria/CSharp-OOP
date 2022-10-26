namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void InitTest()
        {
            warrior = new Warrior("Axel", 10, 100);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual("Axel", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void NameShouldThrowExceptionIfItIsNullEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("", 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 10, 100));
        }

        [Test]
        public void DamageShouldThrowExceptionIfItIsZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Axel", 0, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Axel", -1, 100));
        }

        [Test]
        public void HpShouldThrowExcptionIfItIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Axel", 10, -1));
        }

        [Test]
        public void AttackShouldThrowExceptionIfHpIsLessOrEqualMinimumAttackHp() 
        {
            var warrior1 = new Warrior("Axel", 10, 29);
            var warrior2 = new Warrior("Axel", 10, 30);

            var target = new Warrior("Target", 10, 100);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(target));
            Assert.Throws<InvalidOperationException>(() => warrior2.Attack(target));
        }

        [Test]
        public void AttackShouldThrowExceptionIfEnemyHpIsEqualOrLessThanMinimumAttackHp()
        {
            var target1 = new Warrior("Target", 10, 29);
            var target2 = new Warrior("Target", 10, 30);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target1));
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target2));
        }

        [Test]
        public void AttackShouldThrowExceptionIfTargetHpIsMoreThanWarriors()
        {
            var target = new Warrior("Target", 150, 100);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(target));
        }

        [Test]
        public void AttackShouldDecreaseWarriorsHp()
        {
            var target = new Warrior("Target", 10, 100);
            warrior.Attack(target);

            Assert.AreEqual(90, warrior.HP);
        }

        [Test]
        public void AttackShouldSetTargetHpToZeroIfWarriorsDamageIsMore()
        {
            warrior = new Warrior("Axel", 110, 100);
            var target = new Warrior("Target", 10, 100);

            warrior.Attack(target);
            Assert.AreEqual(0, target.HP);
        }

        [Test]
        public void AttackShouldDecreaseTargetsHp()
        {
            var target = new Warrior("Target", 10, 100);
            warrior.Attack(target);

            Assert.AreEqual(90, target.HP);
        }


    }
}