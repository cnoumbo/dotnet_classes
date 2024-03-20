namespace WordUnscramble;

internal class Program
{
    public static void Main(string[] args)
    {
        bool continueWordUnscrmable = true;

        do
        {
            Console.Write("Please enter the option - F for file and M for Manual : ");
            var option = Console.ReadLine() ?? String.Empty; // Null coalescing

            switch (option.ToUpper())
            {
                case "F" : 
                    Console.Write("Enter scrambled words file name : ");
                    ExecuteScrambleWordsInFileScenario();
                    break;
                case "M" : 
                    Console.Write("Enter scrambled word : ");
                    ExecuteScrambleWordsManualScenario();
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

    private static void ExecuteScrambleWordsManualScenario()
    {
        
    }

    private static void ExecuteScrambleWordsInFileScenario()
    {
        
    }
}