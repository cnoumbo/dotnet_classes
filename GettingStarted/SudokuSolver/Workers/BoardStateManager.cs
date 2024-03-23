using System.Text;

namespace SudokuSolver.Workers;

public class BoardStateManager
{
    public string GenerateState(int[,] board)
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                sb.Append(board[i,j]);
            }
        }
        
        return sb.ToString();
    }

    public bool IsSolved(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == 0 || board[i, j].ToString().Length > 1)
                {
                    return false;
                }
            }
        }

        return true;
    }
}