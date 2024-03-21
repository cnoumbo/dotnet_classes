namespace WordUnscramble.Test.Unit;

public class WordMatcherTest
{
    private WordMatcher _wordMatcher; 
    
    [SetUp]
    public void Setup()
    {
        _wordMatcher = new WordMatcher();
    }

    [Test]
    public void ScrambleWordMatchesGivenWordsInTheList()
    {
        string[] words = { "cat", "rome", "more" };
        string[] scrambledWords = { "tac", "orem" };

        var machedWords = _wordMatcher.Match(scrambledWords, words);

        Assert.IsTrue(machedWords.Count == 3);
        Assert.IsTrue(machedWords[0].ScrambledWord.Equals("tac"));
        Assert.IsTrue(machedWords[0].Word.Equals("cat"));
        Assert.IsTrue(machedWords[1].ScrambledWord.Equals("orem"));
        Assert.IsTrue(machedWords[1].Word.Equals("rome"));
        Assert.IsTrue(machedWords[2].ScrambledWord.Equals("orem"));
        Assert.IsTrue(machedWords[2].Word.Equals("more"));
    }
    
    [Test]
    public void ScrambleWordDoesntMatchGivenWordsInTheList()
    {
        string[] words = { "cat", "rome", "more" };
        string[] scrambledWords = { "tar", "gleea" };

        var machedWords = _wordMatcher.Match(scrambledWords, words);

        Assert.IsTrue(machedWords.Count == 0);
    }
}