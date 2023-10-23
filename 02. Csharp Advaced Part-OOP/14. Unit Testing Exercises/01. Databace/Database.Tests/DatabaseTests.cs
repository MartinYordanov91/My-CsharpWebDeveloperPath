namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Test_Database_Constructor_SetCorrectly(int[] array)
        {
            int expectedCount = array.Length;

            Database database = new Database(array);

            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(array, database.Fetch());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })]
        public void Test_Database_Constructor_ThrowException_AtMoreThan16(int[] array)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => new Database(array));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_Database_AddMethot_ThrowException_AtMoreThan16(int[] array)
        {
            Database database = new Database(array);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(17));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Test_Database_AddMethod_AddItemInCorrctPlace(int[] array)
        {
            Database database = new Database(array);
            database.Add(355);
            int[] arrayCopy = database.Fetch();

            Assert.AreEqual(355, arrayCopy[database.Count - 1]);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 15)]
        public void Test_Database_AddMethod_IncreaceCountCorrectly(int[] array, int curentLenth)
        {
            Database database = new Database(array);
            database.Add(355);


            Assert.AreEqual(curentLenth + 1, database.Count);
        }

        [TestCase(new int[] { })]
        public void Test_Database_RemoveMethod_ThrowException_DatabaseArreyEmpty(int[] array)
        {
            Database database = new Database(array);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Remove(),
                "Array is not empty");

            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 15)]
        public void Test_Database_RemoveMethod_DecreaceCountCorrectly(int[] array, int curentLenth)
        {
            Database database = new Database(array);
            database.Remove();


            Assert.AreEqual(curentLenth - 1, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Test_Database_FetchMethod_WorckCorrectly(int[] array)
        {
            Database database = new Database(array);

            Assert.AreEqual(array, database.Fetch());
        }
    }
}
