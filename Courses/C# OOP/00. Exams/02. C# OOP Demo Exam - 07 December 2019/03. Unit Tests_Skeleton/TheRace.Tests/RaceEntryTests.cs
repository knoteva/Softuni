using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
            var raceEntry = new RaceEntry();

        }

        [Test]
        public void testAddRiderName()
        {
            var rider = new UnitRider("Kate", null);
            Assert.AreEqual("Kate", rider.Name);
        }

        [Test]
        public void CheckAddRiderForNull()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null), "RiderInvalid");
        }

        [Test]
        public void CheckAddRiderExist()
        {
            var raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("Kate", null));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(new UnitRider("Kate", null)), "RiderInvalid");
        }

        [Test]
        public void testCounter()
        {
            var raceEntry = new RaceEntry();
            var rider = new UnitRider("Kate", null);
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void testCounterAfterAdd()
        {
            var raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("Kate", null));
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void test()
        {
            var raceEntry = new RaceEntry();
            var rider = raceEntry.AddRider(new UnitRider("Kate", new UnitMotorcycle("Ya", 2, 5.3)));
            var rider2 = raceEntry.AddRider(new UnitRider("Kate2", new UnitMotorcycle("Ya", 2, 5.3)));
            Assert.AreEqual(2, raceEntry.CalculateAverageHorsePower());
        }
    }
}