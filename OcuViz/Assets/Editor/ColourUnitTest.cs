using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;

public class ColourUnitTest {

	[Test]
	public void Colour_createsColour()
	{
        var colour = new Colour("black", "#iii");
        Assert.AreEqual(colour.getColour(), Color.black);

        colour = new Colour("huh", "#00f");
        Assert.AreEqual(colour.getColour(), Color.blue);
    }

    [Test]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Colour_throwsArgumentNullException1()
    {
        var colour = new Colour(null, "#iii");
        Assert.AreEqual(colour.getColour(), Color.black);
    }

    [Test]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void Colour_throwsArgumentNullException2()
    {
        var colour = new Colour("", null);
        Assert.AreEqual(colour.getColour(), Color.black);
    }

    [Test]
    [ExpectedException(typeof(InvalidColourHexException))]
    public void Colour_throwsInvalidColourHexException()
    {
        var colour = new Colour("huh", "#iii");
        Assert.AreEqual(colour.getColour(), Color.black);
    }
}
