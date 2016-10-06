using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class CustomCollectionFactoryUnitTest {

	[Test]
	public void setOriginal_setsOriginalEntity()
	{
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), new FileReader()), entity);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void setOriginal_throwsArgumentNullException1()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");
        entity = null;

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), new FileReader()), entity);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void setOriginal_throwsArgumentNullException2()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");

        Assert.AreEqual(collectionFactory.setOriginal(entity, null, new FileReader()), entity);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void setOriginal_throwsArgumentNullException3()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween. Not really :/");

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), null), entity);
    }

    [Test]
    public void build_returnsInstanceOfEntity()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();
        var list = new string[3];

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");

        list[0] = "0";
        list[1] = "name";
        list[2] = "C:Assets\\CSV\\Scene2Input1.csv";

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), new FileReader()), entity);
        Assert.IsInstanceOf<Entity>(collectionFactory.build(list));
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();
        var list = new string[3];

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");

        list[0] = "0";
        list[1] = "name";
        list[2] = "C:Assets\\CSV\\Scene2Input1.csv";
        list = null;

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), new FileReader()), entity);
        Assert.IsInstanceOf<Entity>(collectionFactory.build(list));
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var entity = new Entity();
        var collectionFactory = new CustomCollectionFactory();
        var list = new string[4];

        entity.setGameObject(new GameObject());
        entity.setName("BoO! It's !Halloween");

        list[0] = "0";
        list[1] = "name";
        list[2] = "C:Assets\\CSV\\Scene2Input1.csv";

        Assert.AreEqual(collectionFactory.setOriginal(entity, new CommaTokeniser(), new FileReader()), entity);
        Assert.IsInstanceOf<Entity>(collectionFactory.build(list));
    }
}
