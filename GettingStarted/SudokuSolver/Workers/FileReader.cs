namespace SudokuSolver.Workers;

public class FileReader
{
    public int[,] ReadFile(string filename)
    {
        int[,] sudokuBoard = new int[9,9];
        
        try
        {
            var sudokuBoardLines = File.ReadAllLines(filename);

            for (int row = 0; row < sudokuBoardLines.Length; row++)
            {
                string[] sudokuBoardLineElements = sudokuBoardLines[row].Split('|').Skip(1).Take(9).ToArray();

                for (int col = 0; col < sudokuBoardLineElements.Length; col++)
                {
                    sudokuBoard[row, col] = sudokuBoardLineElements[col].Equals(" ")? 0 : Convert.ToInt16(sudokuBoardLineElements[col]);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong file reading the file " + ex.Message, ex);
        }

        return sudokuBoard;
    }
}