using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using EntityProvider;

public class FileReaderUnitTest {

	[Test]
	public void getLines_returnsLinesOfScene1()
	{
        var reader = new FileReader("Assets\\StreamingAssets\\CSV\\Scene1.csv");
        var list = reader.getLines(("Assets\\CSV\\Scene1.csv"));

        Assert.IsInstanceOf<System.Collections.Generic.List<string>>(list);
        Assert.Greater(list.Count, 0);
	}

    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void getLines_throwsArgumentNullException()
    {
        var reader = new FileReader("Assets\\StreamingAssets\\CSV\\Scene1.csv");

        Assert.IsInstanceOf<System.Collections.Generic.List<string>>(reader.getLines(null));
    }

    [Test]
    [ExpectedException(typeof(System.IO.FileNotFoundException))]
    public void getLines_throwsFileNotFoundException()
    {
        var reader = new FileReader("Assets\\CSV\\Scene0.csv");

        Assert.IsInstanceOf<System.Collections.Generic.List<string>>(reader.getLines("Assets\\CSV\\Scene0.csv"));
    }
}
