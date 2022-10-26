namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person p1;
        private Person p2;
        private Database db;

        [SetUp]
        public void InitTest()
        {
            p1 = new Person(1, "a");
            p2 = new Person(2, "b");
            db = new Database(new Person[] {});
        }

        [Test]
        public void ConstructorShouldInitializeDatabase()
        {
            db = new Database(p1, p2);
            Assert.AreEqual(2, db.Count);
        }

        [Test]
        public void AddRangeShouldThrowExceptionIfDatabaseIsFull()
        {
            Assert.Throws<ArgumentException>(() => db = new Database(new Person[17]));
        }

        [Test]
        public void AddShouldThrowExceptionIfUserWithThisUsernameAlreadyExist()
        {
            db = new Database(p1);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(2, "a")));
        }

        [Test]
        public void AddShouldThrowExceptionIfUserWithThisIdAlreadyExist()
        {
            db = new Database(p1);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "b")));
        }

        [Test]
        public void AddShouldAddPerson()
        {
            db.Add(p1);
            Assert.AreEqual(p1, db.FindById(1));
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfThereIsNoSpace()
        {
            db = new Database();
            for (int i = 1; i <= 16; i++)
            {
                var p = new Person(i, i.ToString());
                db.Add(p);
            }

            var x = new Person(50, "x");
            Assert.Throws<InvalidOperationException>(() => db.Add(x));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void RemoveShouldRemovePerson()
        {
            db = new Database(p1, p2);
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            db = new Database(p1, p2);
            db.Remove();
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfUserIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("x"));
        }

        [Test]
        public void FindByUsernameShouldReturnUserIfItIsFound()
        {
            db = new Database(p1);
            Assert.AreEqual(p1, db.FindByUsername("a"));
        }

        [Test]
        public void FindByUsernameShouldBeCaseSensitive()
        {
            db = new Database(p1);
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("A"));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfUserIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(1));
        }

        [Test]
        public void FindByIdShouldReturnUserIfItIsFound()
        {
            db = new Database(p1);
            Assert.AreEqual(p1, db.FindById(1));
        }
    }
}