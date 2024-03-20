namespace WordUnscramble;

internal class Program
{
    private static readonly FileReader _fileReader = new FileReader();
    private static readonly WordMatcher _wordMatcher = new WordMatcher();
    
    private const string _wordListFileName = "wordList.txt";
    
    public static void Main(string[] args)
    {
        bool continueWordUnscrmable = true;

        do
        {
            Console.Write("Entrer scrambled word(s) manually or as a file : F - file / M - manual ");
            var option = Console.ReadLine() ?? String.Empty; // Null coalescing

            switch (option.ToUpper())
            {
                case "F" : 
                    Console.Write("Enter scrambled words file name : ");
                    ExecuteScrambleWordsInFileScenario();
                    break;
                case "M" : 
                    Console.Write("Enter words manually, separate by commas (,) if multiple: ");
                    ExecuteScrambleWordsManualEntryScenario();
                    break;
                default:
                    Console.WriteLine("Option not recognized");
                    break;
            }

            string continueDecision = String.Empty;
            do
            {
                Console.Write("Do you want to continue ? Y/N :");
                continueDecision = Console.ReadLine() ?? String.Empty;
            } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

            continueWordUnscrmable = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
        } while (continueWordUnscrmable);
    }

    private static void ExecuteScrambleWordsManualEntryScenario()
    {
        var manualInput = Console.ReadLine() ?? String.Empty;
        string[] scrambledWords = manualInput.Split(',');
        DisplayMatchedUnscrambledWords(scrambledWords);
    }

    private static void ExecuteScrambleWordsInFileScenario()
    {
        try
        {
            var fileName = Console.ReadLine() ?? String.Empty;
            string[] scrambledWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
    {
        string[] wordList = _fileReader.Read(_wordListFileName);

        List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

        if (matchedWords.Any())
        {
            foreach (var matchedWord in matchedWords)
            {
                Console.WriteLine("Match found for {0} : {1}", matchedWord.ScrambledWord, matchedWord.Word);
            }
        }
        else
        {
            Console.WriteLine("No matches have been found.");
        }
    }
}
