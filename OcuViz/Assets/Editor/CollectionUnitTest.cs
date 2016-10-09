using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;
using System;

public class CollectionUnitTest {

	[Test]
	public void createCollection_returnsCollection()
	{
        var collection = new Collection();
        var entity = new Entity();
        entity.setName("Proto");
        entity.setGameObject(new GameObject("Hello"));
        collection.setEntity(entity);
        collection.setName("ProtoCollection");
        collection.setType("2d");
        collection.setDimension(10);
        collection.setPos(0, 0, 0);

        Assert.AreNotEqual(collection.createCollection(), null);
        Assert.IsInstanceOf<System.Collections.Generic.List<Entity>>(collection.createCollection());
    }

    [Test]
    public void setEntity_setsEntity()
    {
        var collection = new Collection();
        var entity = new Entity();
        entity.setName("Proto");
        entity.setGameObject(new GameObject("Hello"));


        Assert.AreEqual(collection.setEntity(entity), entity);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void setEntity_throwsArgumentNullException()
    {
        var collection = new Collection();
        var entity = new Entity();
        entity = null;
        collection.setEntity(entity);
    }

    [Test]
    public void setType_setsType()
    {
        var collection = new Collection();
        var entity = new Entity();
        var type = "stack";
        entity.setName("Proto");
        entity.setGameObject(new GameObject("Hello"));
        

        Assert.AreEqual(collection.setType(type), type);
    }

    [Test]
    [ExpectedException(typeof(CollectionTypeNotFoundException))]
    public void setType_throwsCollectionTypeNotFoundException()
    {
        var collection = new Collection();
        var entity = new Entity();
        var type = "notdef";
        entity.setName("Proto");
        entity.setGameObject(new GameObject("Hello"));
        collection.setType(type);
    }

    [Test]
    public void setDimension_setsDimension()
    {
        var collection = new Collection();
        var dimension = new uint();
        dimension = 10;

        Assert.AreEqual(collection.setDimension(dimension), dimension);
    }
}
