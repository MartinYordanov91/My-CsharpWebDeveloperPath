using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeTest.Tests
{
    public class DummyTests
    {
        [Test]
        public void ConstructorSholdInicializationCorrectly()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.AreEqual(0, dummy.Health);
            Assert.AreEqual(100, dummy.GiveExperience());
        }

        [Test]
        public void TakeAtackShoThrpwsExceptionIfNoHealt()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(()
                => dummy.TakeAttack(10), "InvalidOperationException");
        }
        [Test]
        public void TakeAtackShoTDecreasDummyHealt()
        {
            Dummy dummy = new Dummy(100, 100);

            dummy.TakeAttack(10);
            dummy.TakeAttack(10);
            dummy.TakeAttack(10);

            Assert.AreEqual(70, dummy.Health);
        }
        [Test]
        public void GiveXpShotThrolExIfDummyNotDeat()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(()
                => dummy.GiveExperience(),
                "Target is not dead.");
        }
        [Test]
        public void IsDeatShotReturnTrueIfdummyHeltIsZero()
        {
            Dummy dummy = new Dummy(10, 100);

            dummy.TakeAttack(10);

            Assert.IsTrue(dummy.IsDead());
        }
    }
}
