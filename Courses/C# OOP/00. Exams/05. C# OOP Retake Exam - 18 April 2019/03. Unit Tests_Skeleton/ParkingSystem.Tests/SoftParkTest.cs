namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {
          
        }
        [Test]
        public void Test1()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            Assert.AreEqual("aaa", c.RegistrationNumber);
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test2()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            Assert.AreEqual("Car:aaa parked successfully!", a.ParkCar("A1", c));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test3()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            Assert.Throws<ArgumentException>(() => a.ParkCar("A77", c));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test4()
        {
            var softPark = new SoftPark();
            Assert.AreEqual(12, softPark.Parking.Count);
        }
        [Test]
        public void Test5()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            a.ParkCar("A1", c);
            Assert.Throws<InvalidOperationException>(() => a.ParkCar("A2", c));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test6()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            a.ParkCar("A1", c);
            Assert.Throws<ArgumentException>(() => a.ParkCar("A1", c));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test7()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            Assert.AreEqual("Kate", c.Make);
            a.ParkCar("A1", c);
            Assert.Throws<ArgumentException>(() => a.RemoveCar("A33", c));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test8()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            var d = new Car("Ka", "aaamjhg");
            a.ParkCar("A1", c);
            Assert.Throws<ArgumentException>(() => a.RemoveCar("A1", d));
            //Assert.AreEqual(0, a.F);
        }
        [Test]
        public void Test9()
        {
            var a = new SoftPark();
            var c = new Car("Kate", "aaa");
            var d = new Car("Ka", "aaamjhg");
            a.ParkCar("A1", c);
            Assert.AreEqual("Remove car:aaa successfully!", a.RemoveCar("A1", c));
        }
    }
}