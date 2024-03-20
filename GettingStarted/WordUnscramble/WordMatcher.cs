namespace WordUnscramble;

public class WordMatcher
{
    public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
    {
        var matchedWords = new List<MatchedWord>();

        foreach (var scrambledWord in scrambledWords)
        {
            var currentScrambleWord = scrambledWord.Trim();
            foreach (var word in wordList)
            {
                if (currentScrambleWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                {
                    matchedWords.Add(BuildMatchedWord(currentScrambleWord, word));
                }
                else
                {
                    // convert to lowercase for consistency. 'A' not equals to 'a' into Array.Sort algorithm
                    var scrambledWordArray = currentScrambleWord.ToLower().ToCharArray();
                    var wordArray = word.ToLower().ToCharArray();
                    Array.Sort(scrambledWordArray);
                    Array.Sort(wordArray);

                    var sortedScrambledWord = new string(scrambledWordArray);
                    var sortedWord = new string(wordArray);
                    
                    if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        matchedWords.Add(BuildMatchedWord(currentScrambleWord, word));
                }
            }
        }

        return matchedWords;
    }

    private MatchedWord BuildMatchedWord(string scrambledWord, string word)
    {
        MatchedWord matchedWord = new MatchedWord
        {
            ScrambledWord = scrambledWord,
            Word = word
        };
        return matchedWord;
    }
}
