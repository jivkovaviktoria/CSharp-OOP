using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void InitTest()
            {
                weapon = new Weapon("x", 10, 5);
                planet = new Planet("y", 10);
            }

            //Weapon tests

            [Test]
            public void TestWeaponConstructor()
            {
                Assert.AreEqual("x", weapon.Name);
                Assert.AreEqual(10, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }

            [Test]
            public void PriceShouldThrowExceptionIfValueIsNegative()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("x", -1, 5));
            }

            [Test]
            public void IncreaseDestructionLevelShouldIncreaseDestructionLevelByOne()
            {
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(6, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearShouldReturnTrueIfDestructionLevelIsEqualOrMoreThanTen()
            {
                weapon.DestructionLevel = 10;
                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void IsNuclearShouldReturnFalseIfDestructionLevelIsBelowTen()
            {
                weapon.DestructionLevel = 9;
                Assert.AreEqual(false, weapon.IsNuclear);
            }

            //Planet tests

            [Test]
            public void TestPlanetConstructor()
            {
                Assert.AreEqual("y", planet.Name);
                Assert.AreEqual(10, planet.Budget);
                Assert.AreEqual(new List<Weapon>(), planet.Weapons);
            }

            [Test]
            public void NameShouldThrowExceptionIfItIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 10));
                Assert.Throws<ArgumentException>(() => new Planet("", 10));
            }

            [Test]
            public void BudgetShouldThrowExceptionIfAmountIsNegative()
            {
                Assert.Throws<ArgumentException>(() => new Planet("x", -1));
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnWeaponsDestructionLevelSum()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(weapon.DestructionLevel, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitShouldIncreaseBudgetWithGivenAmount()
            {
                planet.Profit(10);
                Assert.AreEqual(20, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrowExceptionIfAmountIsMoreThanBudget()
            {
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(30));
            }

            [Test]
            public void SpendFundsShouldDecreaseBudget()
            {
                planet.SpendFunds(5);
                Assert.AreEqual(5, planet.Budget);
            }

            [Test]
            public void AddWeaponShouldThrowExceptionIfThereIsAlreadyWeaponWithThisName()
            {
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void AddWeaponShouldAddWeapon()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void RemoveWeaponShouldRemoveWeaponByName()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("y", 10, 10));

                planet.RemoveWeapon("y");

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.AreEqual(null, planet.Weapons.FirstOrDefault(x => x.Name == "y"));
            }

            [Test]
            public void UpgradeWeaponShouldThrowExceptionIfWeaponDontExist()
            {
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("a"));
            }

            [Test]
            public void UpgradeWeaponShouldIncreaseDestructionLevel()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("x");

                Assert.AreEqual(6, weapon.DestructionLevel);
            }

            [Test]
            public void DestructOpponentShouldThrowExceptionIfOpponentIsStronger()
            {
                var opponent = new Planet("opponent", 20);
                opponent.AddWeapon(new Weapon("x", 5, 100));

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
            }

            [Test]
            public void DestructOpponentShouldDestructOpponent()
            {
                var opponent = new Planet("x", 5);
                planet.AddWeapon(weapon);

                Assert.AreEqual($"{opponent.Name} is destructed!", planet.DestructOpponent(opponent));
            }
        }
    }
}
