using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class FactoryShopUnitTest
{

    [Test]
    public void getFactory_returnsCollectionFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Collection"));
        Assert.IsInstanceOf<CollectionFactory>(shop.getFactory("Collection"));
    }

    [Test]
    public void getFactory_returnsCustomCollectionFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("CustomCollection"));
        Assert.IsInstanceOf<CustomCollectionFactory>(shop.getFactory("CustomCollection"));
    }

    [Test]
    public void getFactory_returnsModelFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Model"));
        Assert.IsInstanceOf<ModelFactory>(shop.getFactory("Model"));
    }

    [Test]
    public void getFactory_returnsLightFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Light"));
        Assert.IsInstanceOf<LightFactory>(shop.getFactory("Light"));
    }

    [Test]
    public void getFactory_returnsShapeFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Shape"));
        Assert.IsInstanceOf<ShapeFactory>(shop.getFactory("Shape"));
    }

    [Test]
    public void getFactory_returnsViewerFactory()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Viewer"));
        Assert.IsInstanceOf<ViewerFactory>(shop.getFactory("Viewer"));
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void getFactory_throwsArgumentNullException()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory(null));
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void getFactory_throwsArgumentException()
    {
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("undefined factory"));
        Assert.IsInstanceOf<LightFactory>(shop.getFactory("Light"));
    }
}
