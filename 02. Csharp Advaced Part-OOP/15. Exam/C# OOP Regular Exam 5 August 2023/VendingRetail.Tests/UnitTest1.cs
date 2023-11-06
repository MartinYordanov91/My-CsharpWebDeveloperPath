using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        private int waterCapacity = 800;
        private int buttonsCount = 9;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
        }

        [Test]
        public void Constructor()
        {
            int waterCapacityXpected = 800;
            int buttonsCountXpected = 9;
            double incomeXpected = 0;
            CoffeeMat coffeeMatt = new CoffeeMat(waterCapacityXpected, buttonsCountXpected);

            Assert.AreEqual(waterCapacityXpected, coffeeMatt.WaterCapacity);
            Assert.AreEqual(buttonsCountXpected, coffeeMatt.ButtonsCount);
            Assert.AreEqual(incomeXpected, coffeeMatt.Income);
        }

        [Test]
        public void FillWaterTank()
        {
            int waterCapacityXpected = 800;

            Assert.AreEqual($"Water tank is filled with {waterCapacityXpected}ml", coffeeMat.FillWaterTank());

            Assert.AreEqual("Water tank is already full!", coffeeMat.FillWaterTank());


        }

        [Test]
        public void AddDrink()
        {
            Assert.IsTrue(coffeeMat.AddDrink("Coffe", 1.20));
            Assert.IsFalse(coffeeMat.AddDrink("Coffe", 2.20));
            coffeeMat.AddDrink("Coffe 2", 2.20);
            coffeeMat.AddDrink("Coffe 3", 2.20);
            coffeeMat.AddDrink("Coffe 4", 2.20);
            coffeeMat.AddDrink("Coffe 5", 2.20);
            coffeeMat.AddDrink("Coffe 6", 2.20);
            coffeeMat.AddDrink("Coffe 7", 2.20);
            coffeeMat.AddDrink("Coffe 8", 2.20);
            coffeeMat.AddDrink("Coffe 9", 2.20);
            Assert.IsFalse(coffeeMat.AddDrink("Coffe 9", 2.20));
        }

        [Test]
        public void BuyDrink()
        {
            coffeeMat.AddDrink("Coffe", 1.20);
            coffeeMat.AddDrink("Coffe 2", 2.29999);

            Assert.AreEqual("CoffeeMat is out of water!",coffeeMat.BuyDrink("Coffe"));
            coffeeMat.FillWaterTank();

            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));

            Assert.AreEqual("CoffeWheatMilck is not available!", coffeeMat.BuyDrink("CoffeWheatMilck"));

            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 1.20$", coffeeMat.BuyDrink("Coffe"));
            Assert.AreEqual($"Your bill is 2.30$", coffeeMat.BuyDrink("Coffe 2"));
         
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink("Coffe"));
        }
         [Test]
        public void CollectIncome()
        {
            coffeeMat.AddDrink("Coffe", 1.20);
            coffeeMat.FillWaterTank();

            Assert.AreEqual(0, coffeeMat.CollectIncome());
            coffeeMat.BuyDrink("Coffe");

            Assert.AreEqual(1.20, coffeeMat.Income);
            Assert.AreEqual(1.20 , coffeeMat.CollectIncome());
            Assert.AreEqual(0, coffeeMat.Income);

        }

    }
}