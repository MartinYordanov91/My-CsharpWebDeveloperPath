namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string expectMake = "Seat";
        private string expectModel = "leon";
        private double expectFuelConsumption = 7.5;
        private double expectFuelCapacity = 60;
        private double expectFuelAmount = 0;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new(expectMake, expectModel, expectFuelConsumption, expectFuelCapacity);
        }

        [Test]
        public void Test_Car_Constructor_WorkCorrectly()
        {
            Assert.AreEqual(expectMake, car.Make);
            Assert.AreEqual(expectModel, car.Model);
            Assert.AreEqual(expectFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(expectFuelAmount, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_Car_PropMake_ThrowExeption(string mmaakkee)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new(mmaakkee, expectModel, expectFuelConsumption, expectFuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_Car_PropModel_ThrowExeption(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new(expectMake, model, expectFuelConsumption, expectFuelCapacity));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Test_Car_PropFuelConsumation_ThrowExeption(int consum)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new(expectMake, expectModel, consum, expectFuelCapacity));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void Test_Car_PropFuelCapacity_ThrowExeption(int capasity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new(expectMake, expectModel, expectFuelConsumption, capasity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }
        [Test]
        public void Test_Car_Refuel_Method_WorkCorrectly()
        {
            car.Refuel(30);

            Assert.AreEqual(30, car.FuelAmount);

            car.Refuel(40);

            Assert.AreEqual(60, car.FuelAmount);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Test_Car_Refuel_Method_ThrowException_ValueZeroOrNegative(double value)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(value),
                "Reffil is not correctly");

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [TestCase(800)]
        [TestCase(700)]
        [TestCase(100)]
        public void Test_Car_Drive_MethodRefuel_Method_WorkCorrectly(double distance)
        {
            double FuelConsumption = 7.5;
            double FuelAmount = 60;

            double expectResult = FuelAmount - ((distance / 100) * FuelConsumption);

            car.Refuel(100);
            car.Drive(distance);

            Assert.AreEqual(expectResult, car.FuelAmount);
        }

        [TestCase(801)]
        [TestCase(900)]
        [TestCase(1000)]
        public void Test_Car_Drive_Method_ThrowException_NotEnoughFuel(double distance)
        {

            double expectResult = (distance / 100) * 7.5;

            car.Refuel(100);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(distance),
                "Drive is not correctly");

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

    }
}