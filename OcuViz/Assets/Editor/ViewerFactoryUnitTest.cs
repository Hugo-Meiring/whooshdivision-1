using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;
using System;

public class ViewerFactoryUnitTest {

	[Test]
	public void build_returnsEntityConstainingViewer()
	{
        var factory = new FactoryShop().getFactory("Viewer");
        string[] list = { "", "viewer", "8", "10", "12", "0", "180", "0" };

        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().transform.position, new Vector3(8, 10, 12));
        Assert.AreEqual(entity.getGameObject().name, "RigidBodyFPSController");
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var factory = new FactoryShop().getFactory("Viewer");
        string[] list = { "", "viewer", "8", "10", "12", "0", "180", "0" };
        list = null;

        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().transform.position, new Vector3(8, 10, 12));
        Assert.AreEqual(entity.getGameObject().name, "RigidBodyFPSController");
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var factory = new FactoryShop().getFactory("Viewer");
        string[] list = { "", "viewer", "8", "10", "12", "0", "180", "0", "some unexpected value" };

        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().transform.position, new Vector3(8, 10, 12));
        Assert.AreEqual(entity.getGameObject().name, "RigidBodyFPSController");
    }

    [Test]
    public void buildBasic_returnsDefaultViewer()
    {
        var button = "";
        var entityLink = "viewer";
        var type = "";
        var entity = new FactoryShop().getFactory("Viewer").buildBasic(button, entityLink, type);

        Assert.AreNotEqual(entity, null);
        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, "RigidBodyFPSController");
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void buildBasic_throwsArgumentNullException()
    {
        var button = "";
        var entityLink = "viewer";
        var type = "";
        entityLink = null;
        var entity = new FactoryShop().getFactory("Viewer").buildBasic(button, entityLink, type);

        Assert.AreNotEqual(entity, null);
        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, "RigidBodyFPSController");
    }
}
