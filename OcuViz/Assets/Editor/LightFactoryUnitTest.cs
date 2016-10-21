using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class LightFactoryUnitTest {

	[Test]
	public void build_buildsSpotlight()
	{
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[9];
        list[0] = "";
        list[1] = "not";
        list[2] = "spot";
        list[3] = "#000edd";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Spot);
    }

    [Test]
    public void build_buildsAreaLight()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[9];
        list[0] = "";
        list[1] = "not";
        list[2] = "area";
        list[3] = "#000edd";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    public void build_buildsDirectionalLight()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[9];
        list[0] = "";
        list[1] = "not";
        list[2] = "directional";
        list[3] = "#000edd";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Directional);
    }

    [Test]
    public void build_buildsPoint()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[9];
        list[0] = "";
        list[1] = "not";
        list[2] = "point";
        list[3] = "#000edd";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Point);
    }

    [Test]
    [ExpectedException(typeof(LightTypeNotFoundException))]
    public void build_throwsLightTypeNotFoundException()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[9];
        list[0] = "";
        list[1] = "not";
        list[2] = "ray";
        list[3] = "#000edd";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "ray";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[11];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "ray";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";
        list = null;

        var light = lightFactory.build(list);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    public void buildBasic_buildsSpotlight()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "spot";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("spot", "liht", "spot");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Spot);
    }

    [Test]
    public void buildBasic_buildsAreaLight()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "area";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("area", "liht", "area");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    public void buildBasic_buildsDirectionalLight()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "directional";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("directional", "liht", "directional");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Directional);
    }

    [Test]
    public void buildBasic_buildsPoint()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "point";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("point", "liht", "point");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Point);
    }

    [Test]
    [ExpectedException(typeof(LightTypeNotFoundException))]
    public void buildBasic_throwsLightTypeNotFoundException()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "ray";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("ray", "liht", "ray");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void buildBasic_throwsArgumentNullException1()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "ray";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic("", null, "ray");
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void buildBasic_throwsArgumentNullException2()
    {
        var lightFactory = new FactoryShop().getFactory("Light");
        var list = new string[10];
        list[0] = "";
        list[1] = "not";
        list[2] = "";
        list[3] = "ray";
        list[4] = "#000edd";
        list[5] = "0";
        list[6] = "0";
        list[7] = "0";
        list[8] = "0";
        list[9] = "0";

        var light = lightFactory.buildBasic(null, "liht", null);
        Assert.AreEqual(light.getGameObject().GetComponent<Light>().type, LightType.Area);
    }
}
