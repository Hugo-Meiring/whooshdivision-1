using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class ModelFactoryUnitTest
{

    [Test]
    public void build_returnsEntity()
    {
        var factory = new FactoryShop().getFactory("Model");
        var list = new string[9];
        list[0] = "";
        list[1] = "model";
        list[2] = "Assets\\Resources\\david.obj";
        list[3] = "1";
        list[4] = "1";
        list[5] = "1";
        list[6] = "1";
        list[7] = "1";
        list[8] = "1";
        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var factory = new FactoryShop().getFactory("Model");
        var list = new string[9];
        list[0] = "";
        list[1] = "model";
        list[2] = "Assets\\Resources\\david.obj";
        list[3] = "1";
        list[4] = "1";
        list[5] = "1";
        list[6] = "1";
        list[7] = "1";
        list[8] = "1";
        list = null;
        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var factory = new FactoryShop().getFactory("Model");
        var list = new string[8];
        list[0] = "";
        list[1] = "model";
        list[2] = "Assets\\Resources\\david.obj";
        list[3] = "1";
        list[4] = "1";
        list[5] = "1";
        list[6] = "1";
        list[7] = "1";
        var entity = factory.build(list);

        Assert.IsInstanceOf<Entity>(entity);
    }

    [Test]
    [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
    public void build_throwsDirectoryNotFoundException()
    {
        var factory = new FactoryShop().getFactory("Model");
        var list = new string[9];
        list[0] = "";
        list[1] = "model";
        list[2] = "Assets\\SO\\notDavid.obj";
        list[3] = "1";
        list[4] = "1";
        list[5] = "1";
        list[6] = "1";
        list[7] = "1";
        list[8] = "1";
        var entity = factory.build(list);
    }

    [Test]
    [ExpectedException(typeof(System.IO.FileNotFoundException))]
    public void build_throwsFileNotFoundException()
    {
        var factory = new FactoryShop().getFactory("Model");
        var list = new string[9];
        list[0] = "";
        list[1] = "model";
        list[2] = "Assets\\Resources\\notDavid.obj";
        list[3] = "1";
        list[4] = "1";
        list[5] = "1";
        list[6] = "1";
        list[7] = "1";
        list[8] = "1";
        var entity = factory.build(list);
    }
}
