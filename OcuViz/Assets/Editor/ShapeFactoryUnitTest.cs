using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;
using System;

public class ShapeFactoryUnitTest
{

    [Test]
    public void build_returnsEntityContainingGameObject()//Shape, EntityLink, parent, type, 3D_FLAG, USE_GRAVITY, mass, xlen, ylen[, zlen], xpos, ypos, zpos
    {
        var factory = new FactoryShop().getFactory("Shape");
        string[] list = { "", "name", "plane", "true", "100", "1", "1", "1", "1", "1", "1" };
        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreNotEqual(entity.getGameObject(), null);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var factory = new FactoryShop().getFactory("Shape");
        string[] list = { "", "name", "null", "plane", "true", "true", "100", "1", "1", "1", "1", "1", "1" };
        list = null;
        var entity = factory.build(list);

        Assert.AreNotEqual(entity.getGameObject(), null);
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var factory = new FactoryShop().getFactory("Shape");
        string[] list = { "", "name", "null", "plane", "true", "true", "100", "1", "1", "1", "1", "1" };
        var entity = factory.build(list);

        Assert.AreNotEqual(entity.getGameObject(), null);
    }
}
