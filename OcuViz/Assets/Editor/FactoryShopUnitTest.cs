using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class FactoryShopUnitTest {

	[Test]
	public void getFactory_returnsEntityFactory()
	{
        var shop = new FactoryShop();

        Assert.IsInstanceOf<EntityFactory>(shop.getFactory("Shape"));
        Assert.IsInstanceOf<LightFactory>(shop.getFactory("Light"));
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
