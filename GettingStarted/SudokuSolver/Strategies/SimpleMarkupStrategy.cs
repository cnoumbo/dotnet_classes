using SudokuSolver.Data;
using SudokuSolver.Workers;

namespace SudokuSolver.Strategies;

public class SimpleMarkupStrategy : ISudokuStrategy
{
    private readonly Mapper _mapper;

    public SimpleMarkupStrategy(Mapper mapper)
    {
        _mapper = mapper;
    }
    public int[,] Solve(int[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == 0 || board[row, col].ToString().Length > 1)
                {
                    var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(board, row, col);
                    var possibilitiesInBlock = GetPossibilitiesInBlock(board, row, col);
                    board[row, col] = GetPossibilitiesIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                }
            }
        }
        return board;
    }

    private int GetPossibilitiesIntersection(int possibilitiesInRowAndCol, int possibilitiesInBlock)
    {
        var possibilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
        var possibilitiesInBlockCharArray = possibilitiesInBlock.ToString().ToCharArray();
        var possibilitiesSubset = possibilitiesInRowAndColCharArray.Intersect(possibilitiesInBlockCharArray);
        return Convert.ToInt32(string.Join(string.Empty, possibilitiesSubset));
    }

    private int GetPossibilitiesInBlock(int[,] board, int givenRow, int givenCol)
    {
        int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Map currentMap = _mapper.Find(givenRow, givenCol);

        for (int col = currentMap.StartCol; col < currentMap.StartCol + 3; col++)
        {
            for (int row = currentMap.StartRow; row < currentMap.StartRow + 3; row++)
            {
                if (IsValidSingle(board[row, col]))
                    possibilities[board[row, col] - 1] = 0;
            }
        }
        
        return Convert.ToInt32(string.Join(String.Empty, possibilities.Select(v => v).Where(v => v != 0)));
    }

    private int GetPossibilitiesInRowAndCol(int[,] board, int givenRow, int givenCol)
    {
        int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        for(int col = 0; col < 9; col++)
            if (IsValidSingle(board[givenRow, col]))
                possibilities[board[givenRow, col] - 1] = 0;
        
        for(int row = 0; row < 9; row++)
            if (IsValidSingle(board[row, givenCol]))
                possibilities[board[row, givenCol] - 1] = 0;

        return Convert.ToInt32(string.Join(String.Empty, possibilities.Select(v => v).Where(v => v != 0)));
    }

    private bool IsValidSingle(int celValue)
    {
        return celValue != 0 && celValue.ToString().Length == 1;
    }
}