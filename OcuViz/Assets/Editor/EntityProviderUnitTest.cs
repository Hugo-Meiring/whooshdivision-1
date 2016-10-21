using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using EntityProvider;
using System;

public class EntityProviderUnitTest
{

    [Test]
    public void createGameObject_createsBasicStackCollection()
    {
        var type = "stack";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject("collection", "test1", type);
        collection.getType();

        Assert.IsInstanceOf<Collection>(collection);
        Assert.AreEqual(collection.getType(), type);
    }

    [Test]
    public void createGameObject_createsBasicRandomCollection()
    {
        var type = "random";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject("collection", "test1", type);
        collection.getType();

        Assert.IsInstanceOf<Collection>(collection);
        Assert.AreEqual(collection.getType(), type);
    }

    [Test]
    public void createGameObject_createsBasicRowCollection()
    {
        var type = "row";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject("collection", "test1", type);
        collection.getType();

        Assert.IsInstanceOf<Collection>(collection);
        Assert.AreEqual(collection.getType(), type);
    }

    [Test]
    public void createGameObject_createsBasic3DCollection()
    {
        var type = "3d";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject("collection", "test1", type);
        collection.getType();

        Assert.IsInstanceOf<Collection>(collection);
        Assert.AreEqual(collection.getType(), type);
    }

    [Test]
    public void createGameObject_createsBasic2DCollection()
    {
        var type = "2d";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject("collection", "test1", type);
        collection.getType();

        Assert.IsInstanceOf<Collection>(collection);
        Assert.AreEqual(collection.getType(), type);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void createGameObject_failsToCreateBasicModel()
    {
        var button = "2d";
        var entityLink = "test1";
        var type = "model";
        var provider = new EntityProvider.EntityProvider();
        var collection = (Collection)provider.CreateGameObject(button, entityLink, type);
    }

    [Test]
    public void createGameObject_returnsBasicShape1()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "plane";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_returnsBasicShape2()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "cube";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_returnsBasicShape3()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "sphere";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_returnsBasicShape4()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "capsule";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_returnsBasicShape5()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "cylinder";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_returnsBasicShape6()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "quad";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    [ExpectedException(typeof(ShapeTypeNotFoundException))]
    public void createGameObject_throwsShapeTypeNotFoundException()
    {
        var button = "shape";
        var entityLink = "test1";
        var type = "ellipse";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().name, entityLink);
    }

    [Test]
    public void createGameObject_createsBasicAreaLight()
    {
        var button = "area";
        var entityLink = "test1";
        var type = "quad";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().GetComponent<Light>().type, LightType.Area);
    }

    [Test]
    public void createGameObject_createsBasicSpotLight()
    {
        var button = "spot";
        var entityLink = "test1";
        var type = "quad";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().GetComponent<Light>().type, LightType.Spot);
    }

    [Test]
    public void createGameObject_createsBasicDirectionalLight()
    {
        var button = "directional";
        var entityLink = "test1";
        var type = "quad";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().GetComponent<Light>().type, LightType.Directional);
    }

    [Test]
    public void createGameObject_createsBasicPointLight()
    {
        var button = "point";
        var entityLink = "test1";
        var type = "quad";
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(button, entityLink, type);

        Assert.IsInstanceOf<Entity>(entity);
        Assert.AreEqual(entity.getGameObject().GetComponent<Light>().type, LightType.Point);
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void createGameObject_cannotFindButton()
    {
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject("soft ice cream", "", "type");
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void createGameObject_throwsArgumentNullException1()
    {
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject(null, "", "type");
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void createGameObject_throwsArgumentNullException2()
    {
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject("", null, "type");
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void createGameObject_throwsArgumentNullException3()
    {
        var provider = new EntityProvider.EntityProvider();
        var entity = provider.CreateGameObject("", "", null);
    }



    [Test]
    public void setBackgroundColour_setsColourToSkybox()
    {
        var huh = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity");
        if (!huh.IsValid()) throw new ArgumentException("U");
        var provider = new EntityProvider.EntityProvider();
        provider.setScene(huh);
        provider.SetBackground("skybox");

        var scene = huh;
        var rootObjects = scene.GetRootGameObjects();
        var canvas = new GameObject();
        var camera = new Camera();
        var viewer = new GameObject();

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (rootObjects[i].name == "RigidBodyFPSController")
            {
                viewer = rootObjects[i];
            }
            if (rootObjects[i].name == "Canvas")
            {
                canvas = rootObjects[i];
            }
        }

        camera = canvas.GetComponent<Camera>();

        Assert.AreEqual(camera.clearFlags, CameraClearFlags.Skybox);
        camera = viewer.GetComponentInChildren<Camera>();
        Assert.AreEqual(camera.clearFlags, CameraClearFlags.Skybox);
    }

    [Test]
    public void setBackgroundColour_setsColourToSolidColor()
    {
        var huh = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity");
        if (!huh.IsValid()) throw new ArgumentException("U");
        var provider = new EntityProvider.EntityProvider();
        var colour = "#000";
        provider.setScene(huh);
        provider.SetBackground(colour);

        var scene = huh;
        var rootObjects = scene.GetRootGameObjects();
        var canvas = new GameObject();
        var camera = new Camera();
        var viewer = new GameObject();

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (rootObjects[i].name == "RigidBodyFPSController")
            {
                viewer = rootObjects[i];
            }
            if (rootObjects[i].name == "Canvas")
            {
                canvas = rootObjects[i];
            }
        }

        camera = canvas.GetComponent<Camera>();

        Assert.AreEqual(camera.clearFlags, CameraClearFlags.SolidColor);
        camera = viewer.GetComponentInChildren<Camera>();
        Assert.AreEqual(camera.clearFlags, CameraClearFlags.SolidColor);
    }
    [Test]
    public void setBackgroundColour_setsColourToHexColour()
    {
        var huh = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity");
        if (!huh.IsValid()) throw new ArgumentException("U");
        var provider = new EntityProvider.EntityProvider();
        var colour = "#12345d";
        provider.setScene(huh);
        provider.SetBackground(colour);

        var scene = huh;
        var rootObjects = scene.GetRootGameObjects();
        var canvas = new GameObject();
        var camera = new Camera();
        var viewer = new GameObject();

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (rootObjects[i].name == "RigidBodyFPSController")
            {
                viewer = rootObjects[i];
            }
            if (rootObjects[i].name == "Canvas")
            {
                canvas = rootObjects[i];
            }
        }

        camera = canvas.GetComponent<Camera>();
        Color color;
        ColorUtility.TryParseHtmlString(colour, out color);
        Assert.AreEqual(camera.backgroundColor, color);
        camera = viewer.GetComponentInChildren<Camera>();
        Assert.AreEqual(camera.backgroundColor, color);
    }

    [Test]
    public void storeEntity_storesEntity()
    {
        var entity = new Entity();
        var entityName = "entity link goes here";
        var provider = new EntityProvider.EntityProvider();
        var pool = provider.getEntityPool();

        Assert.AreEqual(pool.size(), 0);

        entity.setName(entityName);
        provider.StoreEntity(entity);

        Assert.Greater(pool.size(), 0);
        Assert.AreEqual(pool.fetch(entityName), entity);
        Assert.AreEqual(pool.fetch(entityName).getName(), entityName);
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void storeEntity_throwsArgumentNullException()
    {
        var entity = new Entity();
        var entityName = "entity link goes here";
        var provider = new EntityProvider.EntityProvider();
        var pool = provider.getEntityPool();

        Assert.AreEqual(pool.size(), 0);

        entity.setName(entityName);
        entity = null;
        provider.StoreEntity(entity);

        Assert.Greater(pool.size(), 0);
        Assert.AreEqual(pool.fetch(entityName), entity);
        Assert.AreEqual(pool.fetch(entityName).getName(), entityName);
    }

    [Test]
    public void renderScene_placesPoolIntoScene()
    {
        Entity[] entities = new Entity[10];
        var provider = new EntityProvider.EntityProvider();
        var pool = provider.getEntityPool();

        for (int i = 0; i < entities.Length; ++i)
        {
            entities[i] = new Entity();
            entities[i].setName(i.ToString());
            entities[i].setGameObject(new GameObject(i.ToString()));
            provider.StoreEntity(entities[i]);
        }

        provider.setScene(UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity"));
        provider.renderScene();

        var rootObjects = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity").GetRootGameObjects();
        int index, j = 0;

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (int.TryParse(rootObjects[i].name, out index))
            {
                Assert.AreEqual(entities[j].getGameObject(), rootObjects[i]);
                ++j;
            }
        }
    }

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void renderScene_cannotPlaceNullObjects1()
    {
        Entity[] entities = new Entity[10];
        var provider = new EntityProvider.EntityProvider();
        var pool = provider.getEntityPool();

        for (int i = 0; i < entities.Length; ++i)
        {
            entities[i] = new Entity();
            entities[i].setName(i.ToString());
            entities[i].setGameObject(new GameObject(i.ToString()));
            if (i == 7) entities[i] = null;
            provider.StoreEntity(entities[i]);
        }

        provider.setScene(UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity"));
        provider.renderScene();

        var rootObjects = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity").GetRootGameObjects();
        int index, j = 0;

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (int.TryParse(rootObjects[i].name, out index))
            {
                Assert.AreEqual(entities[j].getGameObject(), rootObjects[i]);
                ++j;
            }
        }
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void renderScene_cannotPlaceNullObjects2()
    {
        Entity[] entities = new Entity[10];
        var provider = new EntityProvider.EntityProvider();
        var pool = provider.getEntityPool();

        for (int i = 0; i < entities.Length; ++i)
        {
            entities[i] = new Entity();
            entities[i].setName(i.ToString());
            entities[i].setGameObject(new GameObject(i.ToString()));
            if (i == 7) entities[i] = null;
            pool.store(entities[i]);
        }

        provider.setScene(UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity"));
        provider.renderScene();

        var rootObjects = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets\\Scenes\\scene.unity").GetRootGameObjects();
        int index, j = 0;

        for (int i = 0; i < rootObjects.Length; ++i)
        {
            if (int.TryParse(rootObjects[i].name, out index))
            {
                Assert.AreEqual(entities[j].getGameObject(), rootObjects[i]);
                ++j;
            }
        }
    }
}
