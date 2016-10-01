using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;

public class ConcreteEntityPoolUnitTest {

	[Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.indexOf returns a not-found index when calling it with an
    /// argument which indicates an entity which is not present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.indexOf"/>
    /// </summary>
    [Test]
    public void indexOf_NotFound_ReturnsInvalidIndex()
    {
        var expected = -1;
        var ce_pool = new EntityProvider.ConcreteEntityPool();
        var actual = ce_pool.indexOf("notfound");

        Assert.AreEqual(expected, actual, "Index of -1 is not returned when a nonexistent entity is searched for.");
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.indexOf returns a valid index when calling it with an
    /// argument which indicates an entity which is present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.indexOf"/>
    /// </summary>
    [Test]
    public void indexOf_Found_ReturnsValidIndex()
    {
        var expected = 0;

        var ce_pool = new EntityProvider.ConcreteEntityPool();
        var foo = new EntityProvider.Entity();
        foo.setName("found");
        ce_pool.store(foo);

        var actual = ce_pool.indexOf("found");

        Assert.AreEqual(expected, actual, "Correct index is not returned when a present entity is searched for.");
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.store correctly adds an entity to the pool when calling it with an
    /// argument  entity which is not present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.store"/>
    /// </summary>
    [Test]
    public void store_NoDuplicates_StoresEntity()
    {
        var actual = false;
        var expected = true;

        var ce_pool = new EntityProvider.ConcreteEntityPool();
        actual = (ce_pool.indexOf("added") == -1);

        var foo = new EntityProvider.Entity();
        foo.setName("added");
        ce_pool.store(foo);

        if (actual)
            actual = (ce_pool.indexOf("added") == 0);

        Assert.AreEqual(expected, actual, "Entity is not added to the pool despite not being a duplicate.");
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.store correctly raises an exception when calling it with an
    /// argument entity which is present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.store"/>
    /// <seealso cref="DuplicateEntityException"/>
    /// </summary>
    [Test]
    [ExpectedException(typeof(EntityProvider.DuplicateEntityException))]
    public void store_Duplicates_ThrowsException()
    {
        var ce_pool = new EntityProvider.ConcreteEntityPool();
        var foo = new EntityProvider.Entity();
        var bar = new EntityProvider.Entity();
        foo.setName("added");
        bar.setName("added");
        ce_pool.store(foo);
        ce_pool.store(bar);
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.fetch correctly fetches an entity reference when calling it with an
    /// argument entity name which indicates an entity that is present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.fetch"/>
    /// </summary>
    [Test]
    public void fetch_EntityExists_FetchesCorrectReference()
    {
        var ce_pool = new EntityProvider.ConcreteEntityPool();
        var expected = new EntityProvider.Entity();
        expected.setName("added");
        ce_pool.store(expected);

        var actual = ce_pool.fetch("added");

        Assert.AreEqual(expected, actual, "Entity is not fetched despite being present.");
    }

    /// <summary>
    /// A unit test which checks whether ConcreteEntityPool.fetch correctly raises an exception when calling it with an
    /// argument entity name which indicates an entity that is not present in the EntityPool
    /// <seealso cref="ConcreteEntityPool.fetch"/>
    /// <seealso cref="EntityNotFoundException"/>
    /// </summary>
    [Test]
    [ExpectedException(typeof(EntityProvider.EntityNotFoundException))]
    public void fetch_EntityNotExist_ThrowsException()
    {
        var ce_pool = new EntityProvider.ConcreteEntityPool();
        var foo = ce_pool.fetch("notfound");
    }
}
