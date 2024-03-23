using SudokuSolver.Workers;

namespace SudokuSolver.Strategies;

public class SolverEngine
{
    private readonly BoardStateManager _boardStateManager;
    private readonly Mapper _mapper;

    public SolverEngine(BoardStateManager boardStateManager, Mapper mapper)
    {
        _boardStateManager = boardStateManager;
        _mapper = mapper;
    }

    public bool Solve(int[,] board)
    {
        List<ISudokuStrategy> strategies = new List<ISudokuStrategy>()
        {
            new SimpleMarkupStrategy(_mapper)
        };

        var currenState = _boardStateManager.GenerateState(board);
        var nextState = _boardStateManager.GenerateState(strategies.First().Solve(board));

        while (!_boardStateManager.IsSolved(board) && currenState != nextState)
        {
            currenState = nextState;
            foreach (var strategy in strategies)
            {
                nextState = _boardStateManager.GenerateState(strategy.Solve(board));
            }
        }

        return _boardStateManager.IsSolved(board);
    }
}