namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        string name = "Marto";
        int damage = 100;
        int hp = 100;

        [Test]
        public void Test_Warrior_Constructor()
        {
            Warrior warrior = new(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage , warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Test_Warrior_PropName_ThrowException(string n)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(n, damage, hp));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void Test_Warrior_PropDamage_ThrowException(int d)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, d, hp));
        }
        
        [TestCase(-1)]
        [TestCase(-20)]
        public void Test_Warrior_PropHp_ThrowException(int h)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, h));
        }

        [TestCase(30)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(0)]
        public void Test_Warrior_AtackMethod_ThrowException_WhenAtackingWarriorHpUnderOr30(int h)
        {
            Warrior warrior = new(name, damage, h);
            Warrior warrior1 = new("attacked", damage, hp);

            Assert.Throws<InvalidOperationException>(()
                =>warrior.Attack(warrior1));
        }

        [TestCase(30)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(0)]
        public void Test_Warrior_AtackMethod_ThrowException_WhenAtackedWarriorHpUnderOr30(int h)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior warrior1 = new("attacked", damage , h);

            Assert.Throws<InvalidOperationException>(()
                =>warrior.Attack(warrior1));
        }

        [TestCase(101)]
        [TestCase(110)]
        [TestCase(150)]
        [TestCase(5000)]
        public void Test_Warrior_AtackMethod_ThrowException_WhenAtackingWarriorHpUnderAtackedWarriorAtack(int d)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior warrior1 = new("attacked", d, hp);

            Assert.Throws<InvalidOperationException>(()
                =>warrior.Attack(warrior1));
        }

        [Test]
        public void Test_Warrior_AtackMethod_WorkCorrectly()
        {
            int firstExpectWarrior1Hp = 40;
            int firstExpectWarriorHp = 90;
            int secondExpectWarrior1Hp = 0;
            int secondExpectWarriorHp = 80;
            int damageWarrior = 60;
            int damageWarrior1 = 10;

            Warrior warrior = new(name, damageWarrior, hp);
            Warrior warrior1 = new("attacked", damageWarrior1, hp);

            warrior.Attack(warrior1);

            Assert.AreEqual(firstExpectWarrior1Hp, warrior1.HP);
            Assert.AreEqual(firstExpectWarriorHp, warrior.HP);

            warrior.Attack(warrior1);

            Assert.AreEqual(secondExpectWarrior1Hp, warrior1.HP);
            Assert.AreEqual(secondExpectWarriorHp, warrior.HP);
        }

    }
}