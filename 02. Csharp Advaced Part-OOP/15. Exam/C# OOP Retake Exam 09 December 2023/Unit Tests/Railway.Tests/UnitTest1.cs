namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Marto")]
        [TestCase("Kolio")]
        [TestCase("Gergi")]
        [TestCase("Pesho")]
        public void RailwayStation_Constructor(string name)
        {
            RailwayStation railwayStation = new RailwayStation(name);
            int countExpect = 0;

            Assert.AreEqual(name, railwayStation.Name);
            Assert.AreEqual(countExpect, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(countExpect, railwayStation.DepartureTrains.Count);
        }

        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        [TestCase(" ")]
        public void RailwayStation_Prop_ShotThrowExeption(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase("Djump")]
        [TestCase("Run")]
        [TestCase("Squat")]
        [TestCase("Shoot")]
        public void RailwayStation_NewArrivalOnBoard(string trainInfo)
        {
            RailwayStation railwayStation = new RailwayStation("Spartak");
            int countExpect = 1;

            railwayStation.NewArrivalOnBoard(trainInfo);
            Assert.AreEqual(countExpect, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(trainInfo, railwayStation.ArrivalTrains.Peek());

        }

        [Test]
        public void RailwayStation_TrainHasArrived()
        {
            RailwayStation railwayStation = new RailwayStation("Spartak");
            railwayStation.NewArrivalOnBoard("Djump");
            railwayStation.NewArrivalOnBoard("Run");

            string expect = "There are other trains to arrive before Run.";
            Assert.AreEqual(expect, railwayStation.TrainHasArrived(("Run")));
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
            Assert.AreEqual(2, railwayStation.ArrivalTrains.Count);

            expect = "Djump is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expect, railwayStation.TrainHasArrived(("Djump")));
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual("Djump", railwayStation.DepartureTrains.Peek());
            Assert.AreEqual("Run", railwayStation.ArrivalTrains.Peek());
        }

        [Test]
        public void RailwayStation_TrainHasLeft()
        {
            RailwayStation railwayStation = new RailwayStation("Spartak");
            railwayStation.NewArrivalOnBoard("Djump");
            railwayStation.NewArrivalOnBoard("Run");
            railwayStation.TrainHasArrived(("Djump"));
            railwayStation.TrainHasArrived(("Run"));

            Assert.True(railwayStation.TrainHasLeft("Djump"));
            Assert.False(railwayStation.TrainHasLeft("Djump"));
        }
    }
}