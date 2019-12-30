using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_Counter()
        {
            var a = new RaceEntry();
            Assert.AreEqual(0, a.Counter);
   
        }

        [Test]
        public void Test_Add_Rider()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            Assert.AreEqual("Kate", rider.Name);
            Assert.AreEqual("yamaha", rider.Motorcycle.Model);
            raceEntry.AddRider(rider);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void Test_AddullRider()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            Assert.AreEqual("Kate", rider.Name);
            Assert.AreEqual("yamaha", rider.Motorcycle.Model);          
            Assert.AreEqual("Rider Kate added in race.", raceEntry.AddRider(rider));
            //Assert.Throws<ArgumentException>(() => raceEntry.AddRider(rider));
        }
        [Test]
        public void Test_Add_Same_Rider()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            Assert.AreEqual("Kate", rider.Name);
            Assert.AreEqual("yamaha", rider.Motorcycle.Model);
            raceEntry.AddRider(rider);
           // Assert.AreEqual("Rider Kate added in race.", raceEntry.AddRider(rider));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }
        [Test]
        public void Test_Add_NullRider()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            Assert.AreEqual("Kate", rider.Name);
            Assert.AreEqual("yamaha", rider.Motorcycle.Model);
            raceEntry.AddRider(rider);
            // Assert.AreEqual("Rider Kate added in race.", raceEntry.AddRider(rider));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));
        }
        [Test]
        public void Test_Average_False()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            raceEntry.AddRider(rider);
            //Assert.AreEqual("Rider Kate added in race.", raceEntry.AddRider(rider));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void Test_Average_true()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
            var rider = new UnitRider("Kate", moto);
            var moto2 = new UnitMotorcycle("maha", 10, 6);
            var rider2 = new UnitRider("Lili", moto2);
            raceEntry.AddRider(rider);
            raceEntry.AddRider(rider2);
            Assert.AreEqual(7, raceEntry.CalculateAverageHorsePower());
           //Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_Null_Name()
        {
            var raceEntry = new RaceEntry();
            var moto = new UnitMotorcycle("yamaha", 4, 6);
      
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, moto));
        }
    }
}