using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TesFootballPlayert1()
        {
            ArgumentException exName = Assert.Throws<ArgumentException>(()
                 => new FootballPlayer("", 2, "Goalkeeper"));

            ArgumentException exNumber1 = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Marto", 0, "Goalkeeper"));

            ArgumentException exNumber2 = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Marto", 22, "Goalkeeper"));

            ArgumentException exPosition = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Marto", 2, "Public"));

            ArgumentException exPosition2 = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Marto", 2, " "));

            Assert.AreEqual("Name cannot be null or empty!", exName.Message);
            Assert.AreEqual("Player number must be in range [1,21]", exNumber1.Message);
            Assert.AreEqual("Player number must be in range [1,21]", exNumber2.Message);
            Assert.AreEqual("Invalid Position", exPosition.Message);
            Assert.AreEqual("Invalid Position", exPosition2.Message);

            FootballPlayer player1 = new FootballPlayer("Marto", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Marto", 21, "Midfielder");
            FootballPlayer player3 = new FootballPlayer(" ", 11, "Forward");

            Assert.AreEqual("Goalkeeper", player1.Position);
            Assert.AreEqual("Midfielder", player2.Position);
            Assert.AreEqual("Forward", player3.Position);

            Assert.AreEqual("Marto", player1.Name);
            Assert.AreEqual(1, player1.PlayerNumber);
            Assert.AreEqual(21, player2.PlayerNumber);
            Assert.AreEqual(11, player3.PlayerNumber);
            Assert.AreEqual(" ", player3.Name);
            Assert.AreEqual(0, player3.ScoredGoals);

            player3.Score();
            Assert.AreEqual(1, player3.ScoredGoals);
        }

        [Test]
        public void FootballTeam()
        {
            ArgumentException exName = Assert.Throws<ArgumentException>(()
                => new FootballTeam("",15));

            ArgumentException exCapacity = Assert.Throws<ArgumentException>(()
                => new FootballTeam("mexico", 14));

            FootballTeam footballTeam = new FootballTeam("mexico", 16);
            Assert.AreEqual(0, footballTeam.Players.Count);

            FootballPlayer player1 = new FootballPlayer("Marto", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Marto", 21, "Midfielder");

            string expect = "Added player Marto in position Goalkeeper with number 1";
            Assert.AreEqual(expect, footballTeam.AddNewPlayer(player1));
            Assert.AreEqual(1, footballTeam.Players.Count);
            for (int i = 1; i < 16; i++)
            {
                footballTeam.AddNewPlayer(player1);
            }

            Assert.AreEqual("No more positions available!", footballTeam.AddNewPlayer(player1));
            Assert.AreEqual(null, footballTeam.PickPlayer("Marko"));
            Assert.AreEqual(player1, footballTeam.PickPlayer("Marto"));

            expect = "Marto scored and now has 1 for this season!";
            Assert.AreEqual(expect, footballTeam.PlayerScore(1));

            footballTeam.Capacity = 15;
            Assert.AreEqual(16, footballTeam.Players.Count);
            Assert.AreEqual(15, footballTeam.Capacity);
            Assert.AreEqual("No more positions available!", footballTeam.AddNewPlayer(player1));
        }
    }
}