namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void Test_Create_Aquarium()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 5);
            Assert.AreEqual("Aqua", a.Name);
            Assert.AreEqual(5, a.Capacity);
            Assert.AreEqual(0, a.Count);
            //Assert.AreEqual(0, a.F);
        }

        [Test]
        public void Test_Aquarium_Name_Invalid()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 5));
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 5));
        }

        [Test]
        public void Test_Aquarium_Capacity_Invalid()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Aqua", -1));
        }

        [Test]
        public void Test_Add_Fish_No_Capacity()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mili");
            a.Add(fish1);
            Assert.Throws<InvalidOperationException>(() => a.Add(fish2));
        }
        [Test]
        public void Test_Remove_Fish_No_Exist()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mili");
            a.Add(fish1);
            Assert.Throws<InvalidOperationException>(() => a.RemoveFish("Gogo"));
        }
        [Test]
        public void Test_Sell_Fish_No_Exist()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mili");
            a.Add(fish1);
            Assert.Throws<InvalidOperationException>(() => a.SellFish("Gogo"));
        }

        [Test]
        public void Test_Fish_Count()
        {
            var a = new Aquarium("Aqua", 10);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mili");
            a.Add(fish1);
            a.Add(fish2);
            Assert.AreEqual(2, a.Count);
        }

        [Test]
        public void Test_Sell_Fish_Exist()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 10);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mimi");
            a.Add(fish1);
            a.Add(fish2);
            Assert.AreEqual(false, a.SellFish("Lili").Available);
            Assert.AreEqual("Mimi", a.SellFish("Mimi").Name);
        }
        [Test]
        public void Test_Available()
        {
            //Assert.AreEqual(1, a.Count);
            var a = new Aquarium("Aqua", 10);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mimi");
            a.Add(fish2);
            Assert.AreEqual(true, fish1.Available);
           
        }

        [Test]
        public void Test_Report()
        {
            var a = new Aquarium("Aqua", 10);
            var fish1 = new Fish("Lili");
            var fish2 = new Fish("Mimi");
            a.Add(fish1);
            a.Add(fish2);
            Assert.AreEqual("Fish available at Aqua: Lili, Mimi", a.Report());

        }
    }
}
