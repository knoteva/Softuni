using System;

namespace Telecom.Tests
{
    using NUnit.Framework;
    using Telecom;

    public class Tests
    {
        [Test]
        public void Test1()
        {
            //Assert.AreEqual(1, a.Count);
           // var p = new Phone("");
            Assert.Throws<ArgumentException>(() => new Phone("", "AA"));
        }
        [Test]
        public void Test2()
        {
            //Assert.AreEqual(1, a.Count);
            // var p = new Phone("");
            Assert.Throws<ArgumentException>(() => new Phone("aaaa", ""));
        }
        [Test]
        public void Test3()
        {
            var p = new Phone("KK", "NN");
            p.AddContact("K", "089");
            Assert.Throws<InvalidOperationException>(() => p.AddContact("K", "089"));
        }
        [Test]
        public void Test4()
        {
            var p = new Phone("KK", "NN");
            p.AddContact("K", "089");
            Assert.Throws<InvalidOperationException>(() => p.Call("A"));
        }
        [Test]
        public void Test5()
        {
            var p = new Phone("KK", "NN");
            p.AddContact("K", "089");
            Assert.AreEqual("Calling K - 089...", p.Call("K"));
           // Assert.Throws<InvalidOperationException>(() => p.Call("A"));
        }
    }
}