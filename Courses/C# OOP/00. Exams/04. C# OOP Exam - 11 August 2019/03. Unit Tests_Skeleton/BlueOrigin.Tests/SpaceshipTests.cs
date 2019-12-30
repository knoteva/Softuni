namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void testCount()
        {
            var spaceship = new Spaceship("S", 2);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void testA_Name_Oxy()
        {
            var s = new Spaceship("S", 2);
            var a = new Astronaut("Kate", 20);

            Assert.AreEqual("Kate", a.Name);
            Assert.AreEqual(20, a.OxygenInPercentage);
        }

        [Test]
        public void test_Null_spaceship()
        {
            var s = new Spaceship("S", 2);
            var a = new Astronaut("Kate", 20);

            Assert.AreEqual("Kate", a.Name);
            Assert.Throws<ArgumentNullException>(() => new Spaceship("", 2));
        }
        [Test]
        public void test_Invalid_Capacity()
        {
            var s = new Spaceship("S", 2);
            var a = new Astronaut("Kate", 20);

            Assert.AreEqual("Kate", a.Name);
            Assert.Throws<ArgumentException>(() => new Spaceship("K", -10));
        }
        [Test]
        public void test_Capacity()
        {
            var s = new Spaceship("S", 2);
            var a = new Astronaut("Kate", 20);
            Assert.AreEqual(2, s.Capacity);
        }

        [Test]
        public void testCount2()
        {
            var s = new Spaceship("S", 6);
            var a = new Astronaut("Kate", 20);
            var b = new Astronaut("at", 00);
            s.Add(a);
            s.Add(b);
            Assert.Throws<InvalidOperationException>(() => s.Add(a));
        }
        [Test]
        public void testCount3()
        {
            var s = new Spaceship("S", 1);
            var a = new Astronaut("Kate", 20);
            var b = new Astronaut("at", 00);
            s.Add(a);
            //s.Add(b);
            Assert.Throws<InvalidOperationException>(() => s.Add(b));
        }
        [Test]
        public void testCount4()
        {
            var s = new Spaceship("S", 1);
            var a = new Astronaut("Kate", 20);
            var b = new Astronaut("at", 00);
            s.Add(a);
            //s.Add(b);
            Assert.AreEqual(true, s.Remove(a.Name));
        }
    }

}