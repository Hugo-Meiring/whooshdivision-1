using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using EntityProvider;
using System;

public class CommaTokeniserUnitTest {

	[Test]
	public void tokenise_tokenises()
	{
        var tokeniser = new CommaTokeniser();
        var tokens = tokeniser.tokenise("Hello,there");

        Assert.IsInstanceOf<string[]>(tokens);
        Assert.Greater(tokens.Length, 1);
        Assert.AreEqual(tokens.Length, 2);
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void tokenise_throwsNullReferenceException()
    {
        var toe = new CommaTokeniser();
        var fauxTokens = toe.tokenise(null);
    }

    [Test]
    [ExpectedException(typeof(ListSeparatorNotFoundException))]
    public void tokenise_throwsListSeparatorNotFoundException()
    {
        var toe = new CommaTokeniser();
        var fauxTokens = toe.tokenise("a bunch of gibberish with no comma?");
    }
}
