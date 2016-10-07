using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;

public class CollectionFactoryUnitTest {

	[Test]
	public void build_returnsCollection()
	{
        var collectionFactory = new CollectionFactory();
        var list = new string[7];
        list[0] = "";
        list[1] = "";
        list[2] = "row";
        list[3] = "12";
        list[4] = "0";
        list[5] = "0";
        list[6] = "0";

        collectionFactory.build(list);
    }

    [Test]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void build_throwsArgumentNullException()
    {
        var collectionFactory = new CollectionFactory();
        var list = new string[8];
        list = null;

        collectionFactory.build(list);
    }

    [Test]
    [ExpectedException(typeof(InvalidListLengthException))]
    public void build_throwsInvalidListLengthException()
    {
        var collectionFactory = new CollectionFactory();
        var list = new string[8];

        collectionFactory.build(list);
    }

    [Test]
    public void buildBasic_returnsCollection()
    {
        var collectionFactory = new CollectionFactory();

        Assert.AreNotEqual(collectionFactory.buildBasic("", "", "3d"), null);
    }

    [Test]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void buildBasic_throwsArgumentNullException1()
    {
        var collectionFactory = new CollectionFactory();

        Assert.AreNotEqual(collectionFactory.buildBasic("", null, "3d"), null);
    }

    [Test]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void buildBasic_throwsArgumentNullException2()
    {
        var collectionFactory = new CollectionFactory();

        Assert.AreNotEqual(collectionFactory.buildBasic("", "", null), null);
    }
}
