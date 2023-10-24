namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_Arena_Constructor()
        {
            int expected = 0;

            Arena arena = new Arena();

            Assert.AreEqual(expected, arena.Count);
            CollectionAssert.IsEmpty(arena.Warriors);
        }

        [Test]
        public void Test_Arena_EnrollMethod_ThrowException_NameExists()
        {
            Warrior warrior = new("first", 10, 100);
            Warrior warrior1 = new("first", 100, 50);
            Arena arena = new Arena();

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                =>arena.Enroll(warrior1));
            Assert.Throws<InvalidOperationException>(()
                =>arena.Enroll(warrior));

        }


        [TestCase("" , "mmm")]
        [TestCase(null , "mmm")]
        [TestCase("dsadsad sda sad asd asd a" , "   ")]
        [TestCase("" , " ")]
        [TestCase("sss" , null)]
        public void Test_Arena_FightMethod_ThrowException_NameNoExists(string first , string second)
        {
            Warrior warrior = new("Marto", 10, 100);
            Warrior warrior1 = new("Niki", 100, 50);
            Arena arena = new Arena();

            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(()
                =>arena.Fight(first,second));
        }
        [Test]
        public void Test_Arena_FightMethod_WorkCorrectly()
        {
            int martoHp = 90;
            int nikiHp = 60;

            Warrior warrior = new("Marto", 40, 100);
            Warrior warrior1 = new("Niki", 10, 100);
            Arena arena = new Arena();

            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Fight("Marto", "Niki");

            Assert.AreEqual(martoHp, warrior.HP);
            Assert.AreEqual(nikiHp, warrior1.HP);
        }
    }
}
