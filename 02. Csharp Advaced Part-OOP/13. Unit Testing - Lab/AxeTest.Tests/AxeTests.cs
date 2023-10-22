using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeTest.Tests
{
    public class AxeTests
    {
        [Test]
        public void AxeConstructorConstructorInitilization()
        {
            Axe axe = new Axe(10, 10);

            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
        }

        [Test]
        public void AxeShotLoseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AxeShotbeCantAtackWheatDurabilityZero()
        {
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy)
                , "Axe is broken.");
        }
    }
}
