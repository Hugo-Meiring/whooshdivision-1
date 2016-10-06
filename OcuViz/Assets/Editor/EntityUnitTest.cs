using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;
using System;

public class EntityUnitTest {

	[Test]
    public void setGameObject_setsGameObject()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);

        Assert.AreEqual(entity.getGameObject(), go);
    }

    [Test]
    [ExpectedException(typeof(System.NullReferenceException))]
    public void setGameObject_throwsNullReferenceException()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        go = null;
        entity.setGameObject(go);
    }

    [Test]
    public void setName_setsName()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);
        entity.setName(name);

        Assert.AreEqual(entity.getName(), name);
    }

    [Test]
    [ExpectedException(typeof(System.NullReferenceException))]
    public void setName_throwsNullReferenceException()
    {
        var name = "";
        name = null;
        var entity = new EntityProvider.Entity();
        var go = new GameObject();
        entity.setGameObject(go);
        entity.setName(name);
    }

    [Test]
    public void addColour_addsColour()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);
        entity.setName(name);

        var colour = new EntityProvider.Colour("blue", "#00f");
        entity.addColour(colour);

        Assert.AreEqual(entity.getGameObject().GetComponent<Renderer>().material.color, colour.getColour());
    }

    [Test]
    [ExpectedException(typeof(System.NullReferenceException))]
    public void addColour_throwsNullReferenceException()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);
        entity.setName(name);

        var colour = new EntityProvider.Colour("blue", "#00f");
        colour = null;
        entity.addColour(colour);
    }

    [Test]
    public void addTexture_findsTexture()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);
        entity.setName(name);

        entity.addTexture("moon_surface", true);
    }

    [Test]
    [ExpectedException(typeof(System.NullReferenceException))]
    public void addTexture_throwsNullReferenceException()
    {
        var name = "Pokemon";
        var entity = new EntityProvider.Entity();
        var go = new GameObject(name);
        entity.setGameObject(go);
        entity.setName(name);

        entity.addTexture("blah", true);
    }
}
