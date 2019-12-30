using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Test_Create_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 2);
        var a = new HeroRepository().Create(hero1);
        Assert.AreEqual("Successfully added hero Kate with level 2", a);
    }

    [Test]
    public void Test_Create_Null_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 2);
        var a = new HeroRepository();
        //a.Create(hero1);
        Assert.Throws<ArgumentNullException>(() => a.Create(null));
    }

    [Test]
    public void Test_Create_Duplicate_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 2);
        var a = new HeroRepository();
        a.Create(hero1);
        Assert.Throws<InvalidOperationException>(() => a.Create(hero1));
    }

    [Test]
    public void Test_Remove_Null_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 2);
        var a = new HeroRepository();
        a.Remove(hero1.Name);
        Assert.Throws<ArgumentNullException>(() => a.Remove(null));
    }

    [Test]
    public void Test_Remove_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 2);
        var a = new HeroRepository();
        //a.Remove(hero1.Name);
        //Assert.AreEqual(false, a.Remove(hero1.Name));
        Assert.AreEqual(false, a.Remove(hero2.Name));
    }

    [Test]
    public void Test_GetHeroWithHighestLevel_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 4);
        var a = new HeroRepository();
        a.Create(hero1);
        a.Create(hero2);
        //Assert.AreEqual(false, a.Remove(hero1.Name));
        Assert.AreEqual(hero2, a.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_GetHero_Hero()
    {
        //Assert.AreEqual(1, a.Count);
        var hero1 = new Hero("Kate", 2);
        var hero2 = new Hero("Kat", 4);
        var a = new HeroRepository();
        a.Create(hero1);
        a.Create(hero2);
        //Assert.AreEqual(false, a.Remove(hero1.Name));
        Assert.AreEqual(hero2, a.GetHero(hero2.Name));
    }
}