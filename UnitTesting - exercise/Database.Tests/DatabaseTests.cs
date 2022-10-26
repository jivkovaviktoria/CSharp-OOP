namespace Tests
{
    using NUnit.Framework;
    using System;
    using Database;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        private readonly int[] data = new int[] {1, 2, 3};

        [SetUp]
        public void SetUp()
        {
            db = new Database(data);
        }
        [Test]
        public void Test_Database_Throws_Exception_When_Count_Is_Not_Equal_To_16()
        {
            Assert.AreEqual(3, db.Count);
        }

        [Test]
        public void Test_If_Method_Add_Adds_Element_On_The_Next_Position()
        {
            db.Add(3);
            Assert.AreEqual(4, db.Count);
        }

        [Test]
        public void Test_If_Method_Add_Throws_Exception_If_Database_Count_Is_16()
        {
            db = new Database(new int[16]);
            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }

        [Test]
        public void Test_If_Remove_Removes_The_Last_Element()
        {
            db.Remove();
            Assert.AreEqual(2, db.Count);
        }

        [Test]
        public void Test_Remove_From_Empty_Database_Should_Throw_Exception()
        {
            db = new Database(new int[0]);
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void Test_Fetch_Should_Return_All_Elements_In_Array()
        {
            var elements = db.Fetch();
            var expected = new int[] { 1, 2, 3 };

            Assert.AreEqual(expected, elements);
        }
    }
}
