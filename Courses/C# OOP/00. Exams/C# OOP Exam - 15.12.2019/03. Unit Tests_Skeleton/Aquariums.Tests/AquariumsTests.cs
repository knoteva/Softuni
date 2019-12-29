namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void CheckConstructor()
        {
            var aquarium = new Aquarium("zaza", 7);

            Assert.AreEqual("zaza", aquarium.Name);
            Assert.AreEqual(7, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void CheckNameForNuly()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 7));
        }

        [Test]
        public void CheckCapacityForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("zaza", -7));
        }

        [Test]
        public void CheckRemove()
        {
            var aquarium = new Aquarium("zaza", 7);
            aquarium.Add( new Fish("didi"));
            aquarium.Add(new Fish("sisi"));
            aquarium.Add(new Fish("sasa"));

            aquarium.RemoveFish("sisi");

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void CheckRemoveForException()
        {
            var aquarium = new Aquarium("zaza", 7);
            aquarium.Add( new Fish("didi"));
            aquarium.Add(new Fish("sisi"));
            aquarium.Add(new Fish("sasa"));

            string name = "lili";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name));
        }

        [Test]
        public void CheckSellFishForException()
        {
            var aquarium = new Aquarium("zaza", 7);
            aquarium.Add( new Fish("didi"));
            aquarium.Add(new Fish("sisi"));
            aquarium.Add(new Fish("sasa"));

            string name = "lili";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name));
        }

        [Test]
        public void CheckSellFish()
        {
            var aquarium = new Aquarium("zaza", 7);

            var fish = new Fish("sasa");

            aquarium.Add( new Fish("didi"));
            aquarium.Add(new Fish("sisi"));
            aquarium.Add(fish);

            string name = "sasa";

            Assert.AreEqual(fish, aquarium.SellFish(name));
        }

        [Test]
        public void CheckReport()
        {
            var aquarium = new Aquarium("zaza", 7);

            var fish = new Fish("sasa");

            aquarium.Add(fish);

            string result = "Fish available at zaza: sasa";

            Assert.AreEqual(result, aquarium.Report());
        }

        [Test]
        public void CheckSellAddForException()
        {
            var aquarium = new Aquarium("zaza", 2);
            aquarium.Add(new Fish("didi"));
            aquarium.Add(new Fish("sisi"));
            ;
;
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("sasa")));
        }
    }
}
