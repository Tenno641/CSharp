using NUnit.Framework;
using QuoteFinder.StringFinders;

namespace UtilitiesTests;

[TestFixture]
public class StringFinderTests
{
    [Test]
    public void ContainsWholeWord_ShallReturnTrue_IfWordExistInText()
    {
        Assert.IsTrue(StringFinder.ContainsWholeWord("category I'm ready for the war", "ready"));
    }

    [Test]
    public void ContainsWholeWord_ShallReturnTrue_IfWordExistInTextWithPostfix()
    {
        Assert.IsTrue (StringFinder.ContainsWholeWord("cat I'm ready for the` war", "the"));
    }

    [Test]
    public void ContainsWholeWord_ShallReturnTrue_IfWordExistInTextWithPrefix()
    {
        Assert.IsTrue(StringFinder.ContainsWholeWord("cat I'm ready for `the war", "the"));
    }

    [Test]
    public void ContainsWholeWord_Should_Find_Word_After_Substring_Match()
    {
        string text = "I love category but my pet cat is awesome";
        string word = "cat";

        Assert.IsTrue(StringFinder.ContainsWholeWord(text, word));
    }
}
