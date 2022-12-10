using System;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer fp;
        private FootballTeam ft;
        [SetUp]
        public void Setup()
        {
            fp = new FootballPlayer("x", 1, "Goalkeeper");
            ft = new FootballTeam("x", 16);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("x", fp.Name);
            Assert.AreEqual(1, fp.PlayerNumber);
            Assert.AreEqual("Goalkeeper", fp.Position);
            Assert.AreEqual(0, fp.ScoredGoals);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentException>(() => fp = new FootballPlayer("", 1, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => fp = new FootballPlayer(null, 1, "X"));
        }

        [Test]
        public void Test3()
        {
            Assert.Throws<ArgumentException>(() => fp = new FootballPlayer("x", 0, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => fp = new FootballPlayer("x", 22, "Goalkeeper"));
            Assert.DoesNotThrow(() => fp = new FootballPlayer("c", 2, "Goalkeeper"));
        }

        [Test]
        public void Test4()
        {
            Assert.Throws<ArgumentException>(() => fp = new FootballPlayer("x", 2, "asdfg"));
        }

        [Test]
        public void Test5()
        {
            Assert.DoesNotThrow(() => fp = new FootballPlayer("x", 4, "Midfielder"));
        }

        [Test]
        public void Test6()
        {
            fp.Score();
            Assert.AreEqual(1, fp.ScoredGoals);
        }

        [Test]
        public void Test7()
        {
            Assert.AreEqual("x", ft.Name);
            Assert.AreEqual(16, ft.Capacity);
            Assert.AreEqual(0, ft.Players.Count);
        }

        [Test]
        public void Test8()
        {
            Assert.Throws<ArgumentException>(() => ft = new FootballTeam(null, 16));
            Assert.Throws<ArgumentException>(() => ft = new FootballTeam("", 16));
        }

        [Test]
        public void Test9()
        {
            Assert.Throws<ArgumentException>(() => ft = new FootballTeam("x", 14));
        }

        [Test]
        public void Test10()
        {
            ft.AddNewPlayer(fp);
            Assert.AreEqual(1, ft.Players.Count);
        }

        [Test]
        public void Test11()
        {
            for (int i = 0; i < 16; i++)
            {
                ft.AddNewPlayer(fp);
            }

            Assert.AreEqual("No more positions available!", ft.AddNewPlayer(fp));
        }

        [Test]
        public void Test12()
        {
            var expected = $"Added player {fp.Name} in position {fp.Position} with number {fp.PlayerNumber}";
            Assert.AreEqual(expected, ft.AddNewPlayer(fp));
        }

        [Test]
        public void Test13()
        {
            ft.AddNewPlayer(fp);
            Assert.AreEqual(fp, ft.PickPlayer("x"));
        }

        [Test]
        public void Test14()
        {
            var expected = $"{fp.Name} scored and now has {fp.ScoredGoals+1} for this season!";

            ft.AddNewPlayer(fp);
            Assert.AreEqual(expected, ft.PlayerScore(1));
        }
    }
}