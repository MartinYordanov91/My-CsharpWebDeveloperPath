namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people = new Person[10];


        [TestCase(1203102665, "Marto")]
        [TestCase(9993102618, "Georgi")]
        [TestCase(5204602682, "Nikola")]
        public void Test_Person_Constructors_SholdWorckCorrectly(long id, string name)
        {
            Person person = new Person(id, name);

            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }

        [SetUp]
        public void SetUp()
        {
            Person person = new Person(1234567891, "Marto");
            Person person1 = new Person(2345678912, "Plamen");
            Person person2 = new Person(3456789123, "Niki");
            Person person3 = new Person(4567891234, "Nasko");
            Person person4 = new Person(5678912345, "Marin");
            Person person5 = new Person(6789123456, "Martea");
            Person person6 = new Person(7891234567, "Mario");
            Person person7 = new Person(8912345678, "Mitko");
            Person person8 = new Person(9123456789, "Misho");
            Person person9 = new Person(1237894561, "Margarita");


            people[0] = person;
            people[1] = person1;
            people[2] = person2;
            people[3] = person3;
            people[4] = person4;
            people[5] = person5;
            people[6] = person6;
            people[7] = person7;
            people[8] = person8;
            people[9] = person9;

        }

        [TestCase(1234567891, "Marto")]
        [TestCase(6789123456, "Martea")]
        [TestCase(7891234567, "Mario")]
        [TestCase(8912345678, "Mitko")]
        [TestCase(9123456789, "Misho")]
        public void Test_Database_FindById_Method_WorckCorectly(long id, string name)
        {
            Person expected = new(id, name);

            Database database = new Database(people);
            Person actuality = database.FindById(id);

            Assert.AreEqual(expected.Id, actuality.Id);
            Assert.AreEqual(expected.UserName, actuality.UserName);
        }

        [TestCase(12349567891)]
        [TestCase(67899123456)]
        [TestCase(78919234567)]
        [TestCase(89129345678)]
        [TestCase(91239456789)]
        public void Test_Database_FindById_Method_ThrowException_IdNoExist(long id)
        {
            Database database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindById(id)
                , $"Exists person wheat Id: {id}");

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(-6789456)]
        [TestCase(-7891567)]
        [TestCase(-8912678)]
        [TestCase(-9123789)]
        public void Test_Database_FindById_Method_ThrowException_IdNegative(long id)
        {
            Database database = new Database(people);

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(id)
            , $"Id: {id} is posetive");

            Assert.AreEqual("Id should be a positive number!", exception.ParamName);
        }

        [TestCase(1234567891, "Marto")]
        [TestCase(6789123456, "Martea")]
        [TestCase(7891234567, "Mario")]
        [TestCase(8912345678, "Mitko")]
        [TestCase(9123456789, "Misho")]
        public void Test_Database_FindByUsername_Method_WorckCorectly(long id, string name)
        {
            Person expected = new(id, name);

            Database database = new Database(people);
            Person actuality = database.FindByUsername(name);

            Assert.AreEqual(expected.Id, actuality.Id);
            Assert.AreEqual(expected.UserName, actuality.UserName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_Database_FindByUsername_Method_ThrowException_StringIsNullOrEmpty(string name)
        {
            Database database = new Database(people);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(name)
            , $"Username: {name} is does not null or empty");

            Assert.AreEqual("Username parameter is null!", exception.ParamName);
        }


        [TestCase("NoMarto")]
        [TestCase("NoMartea")]
        [TestCase("NoMario")]
        [TestCase("NoMitko")]
        [TestCase("NoMisho")]
        public void Test_Database_FindByUsername_Method_ThrowException_UserNameDoesNotExist(string name)
        {
            Database database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(name)
            , $"Username: {name} is does not exist");

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void Test_Database_Remove_Method_WorckCorectly()
        {
            Database database = new Database(people);

            int curentLenght = database.Count;

            database.Remove();
            Assert.AreEqual(curentLenght - 1, database.Count);

            for (int i = 0; i < 9; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(()
                => database.Remove(),
                "Noting stop RemulveMethod when is empty");
        }

        [Test]
        public void Test_Database_Add_Method_WorckCorectly()
        {
            Database database = new Database(people);
            Person person = new(123456, "Nqkoi");
            database.Add(person);

            Assert.AreEqual(11, database.Count);
        }

        [TestCase(12345678911, "Marto")]
        public void Test_Database_Add_Method_ThrowException_DatabaseCountOver16(long id, string name)
        {
            Database database = new Database(people);

            for (int i = 0; i < 6; i++)
            {
                Person person = new(id + i, name + $"{i}");
                database.Add(person);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(1, "mmmmmmmmmm")),
                "Add method ceep adding persons");

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }


        [TestCase("Marto")]
        [TestCase("Martea")]
        [TestCase("Mario")]
        [TestCase("Mitko")]
        [TestCase("Misho")]
        public void Test_Database_Add_Method_ThrowException_WhenUserNameExist(string name)
        {
            Database database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(1, name)),
                "Add method does not kach equals username");

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [TestCase(6789123456)]
        [TestCase(7891234567)]
        [TestCase(8912345678)]
        [TestCase(9123456789)]
        [TestCase(1237894561)]
        public void Test_Database_Add_Method_ThrowException_WhenIdExist(long id)
        {
            Database database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(id, "m")),
                "Add method does not kach equals users id");

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [TestCase(12345678911, "Marto")]
        public void Test_Database_Constructor_ThrowException_WhenColectionCountOver16(long id, string name)
        {
            Person[] ppl = new Person[20];
            for (int i = 0; i < people.Length; i++)
            {
                ppl[i] = people[i];
            }

            for (int i = 10; i < 17; i++)
            {
                Person person = new(id + i, name + $"{i}");
                ppl[i] = person;
            }

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Database(ppl)
                ,"Constructor create instance wheat bigger colection");

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }
    }
}