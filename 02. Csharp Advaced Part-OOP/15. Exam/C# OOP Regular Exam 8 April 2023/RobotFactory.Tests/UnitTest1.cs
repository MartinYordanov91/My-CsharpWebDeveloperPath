using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SupplementClass()
        {
            Supplement supplement = new Supplement("Marto", 12345);

            Assert.AreEqual("Marto", supplement.Name);
            Assert.AreEqual(12345, supplement.InterfaceStandard);
            Assert.AreEqual("Supplement: Marto IS: 12345", supplement.ToString());

            supplement.Name = "Pesho";
            supplement.InterfaceStandard = 987654;

            Assert.AreEqual("Pesho", supplement.Name);
            Assert.AreEqual(987654, supplement.InterfaceStandard);
            Assert.AreEqual("Supplement: Pesho IS: 987654", supplement.ToString());
        }

        [Test]
        public void RobotClass()
        {
            Robot robot = new Robot("Micser", 102.556, 123456);
            Supplement supplement = new Supplement("Turbo", 456789);

            Assert.AreEqual("Micser", robot.Model);
            Assert.AreEqual(102.556, robot.Price);
            Assert.AreEqual(123456, robot.InterfaceStandard);
            Assert.AreEqual(0, robot.Supplements.Count);
            Assert.AreEqual("Robot model: Micser IS: 123456, Price: 102.56", robot.ToString());

            robot.Model = "ChefRobot";
            robot.Price = 200;
            robot.InterfaceStandard = 456789;
            robot.Supplements.Add(supplement);

            Assert.AreEqual("ChefRobot", robot.Model);
            Assert.AreEqual(200, robot.Price);
            Assert.AreEqual(456789, robot.InterfaceStandard);
            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.AreEqual("Robot model: ChefRobot IS: 456789, Price: 200.00", robot.ToString());
        }

        [Test]
        public void FactoryConstructor()
        {
            Factory factory = new Factory("Lidal", 10);

            Assert.AreEqual("Lidal", factory.Name);
            Assert.AreEqual(10, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);

            factory.Name = "MyMarcet";
            factory.Capacity = 100;
            factory.Robots.Add(new Robot("printer", 20, 123456));
            factory.Supplements.Add(new Supplement("turbo", 123456));

            Assert.AreEqual("MyMarcet", factory.Name);
            Assert.AreEqual(100, factory.Capacity);
            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void ProduceRobot()
        {
            Factory factory = new Factory("Lidal", 1);

            Assert.AreEqual("Produced --> Robot model: Micser IS: 12345, Price: 100.00", factory.ProduceRobot("Micser", 100, 12345));


            Assert.AreEqual("The factory is unable to produce more robots for this production day!", factory.ProduceRobot("Micser", 120, 456789));
        }

        [Test]
        public void ProduceSupplement()
        {
            Factory factory = new Factory("Lidal", 1);

            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual("Supplement: Turbo IS: 123456", factory.ProduceSupplement("Turbo", 123456));
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobot()
        {
            Factory factory = new Factory("Lidal", 10);
            Robot robot = new Robot("Micser", 102.556, 123456);
            Supplement supplement = new Supplement("Turbo", 456789);
            Supplement supplement1 = new Supplement("Nitro", 123456);

            Assert.IsTrue(factory.UpgradeRobot(robot, supplement1));
            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement1));
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void SellRobot()
        {
            Factory factory = new Factory("Lidal", 10);

            Robot robot = new Robot("printer", 200, 123456);
            Robot robot2 = new Robot("printer", 300, 123456);
            Robot robot3 = new Robot("printer", 100, 123456);

            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Assert.AreEqual(robot, factory.SellRobot(201));
            Assert.AreEqual(robot, factory.SellRobot(200));
            Assert.AreEqual(robot3, factory.SellRobot(199));
            Assert.AreEqual(null, factory.SellRobot(99));
        }
    }
}