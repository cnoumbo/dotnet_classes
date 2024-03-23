using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Mapper mapper = new Mapper();
            BoardStateManager boardStateManager = new BoardStateManager();
            SolverEngine solverEngine = new SolverEngine(boardStateManager, mapper);
            FileReader fileReader = new FileReader();
            BoardDisplay boardDisplay = new BoardDisplay();
            
            Console.Write("Please enter the filename containing the sudoku Puzzle: ");
            var filename = Console.ReadLine() ?? String.Empty;

            var sudoBoard = fileReader.ReadFile(filename);
            boardDisplay.Display("Initial State", sudoBoard);

            bool isSudokuSolved = solverEngine.Solve(sudoBoard);
            boardDisplay.Display("Final state", sudoBoard);
            
            Console.WriteLine(isSudokuSolved ? "You have successfully solved this Sudoku Puzzle!!" : "Unfortunately, current algorithm(s) were not strong enough to solve the current Sudoku Puzzle!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} : {1}", "Sudoku Puzzle cannot be solved because there was an error", ex.Message);
            // throw new Exception(ex.Message, ex); // Log error if it happens.
        }
    }
}

