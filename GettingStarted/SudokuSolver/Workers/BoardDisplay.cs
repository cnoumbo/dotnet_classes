namespace SudokuSolver.Workers;

public class BoardDisplay
{
    public void Display(string title, int[,] board)
    {
        if(!title.Equals(String.Empty)) Console.WriteLine("{0} {1}", title, Environment.NewLine);

        for (int i = 0; i < board.GetLength(0); i++)
        {
            Console.Write('|');
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write("{0}{1}", board[i,j], '|');
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}