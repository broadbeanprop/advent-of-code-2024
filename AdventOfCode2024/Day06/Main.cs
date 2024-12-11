using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day06;

public class Main(char[][] input)
{
    private char[][] _grid = input.Select(a => a.ToArray()).ToArray();
    private List<(int Row, int Column, Direction Direction)> _visitedPositions = [];
    private (int Row, int Column) _startingPosition;
    private (int Row, int Column) _currentPosition;
    private Direction _currentDirection = Direction.Up;

    public void FindCurrentPosition()
    {
        var point = GridHelper.FindInGrid(_grid, '^').Single();

        _currentPosition.Row = point.Row;
        _currentPosition.Column = point.Column;
        _startingPosition.Row = point.Row;
        _startingPosition.Column = point.Column;

        _visitedPositions.Add((_currentPosition.Row, _currentPosition.Column, Direction.Up));
    }

    public int GetAnswerPart1()
    {
        var keepWalking = true;

        while (keepWalking)
        {
            try
            {
                var nextPosition = GetNextPosition();

                if (_grid[nextPosition.Row][nextPosition.Column] is '#')
                    TurnRight();

                if (_grid[nextPosition.Row][nextPosition.Column] is '.' or '^')
                {
                    _currentPosition.Row = nextPosition.Row;
                    _currentPosition.Column = nextPosition.Column;

                    var inLoop = _visitedPositions.Any(x =>
                        x.Row == _currentPosition.Row &&
                        x.Column == _currentPosition.Column &&
                        x.Direction == _currentDirection);

                    if (inLoop)
                    {
                        return -1;
                    }

                    _visitedPositions.Add((_currentPosition.Row, _currentPosition.Column, _currentDirection));
                }
            }
            catch (IndexOutOfRangeException)
            {
                keepWalking = false;
            }
        }

        return _visitedPositions.Select(x => new { x.Row, x.Column }).Distinct().Count();
    }

    public int GetAnswerPart2()
    {
        var answer = 0;

        for (var row = 0; row < _grid.Length; row++)
        {
            for (var col = 0; col < _grid[row].Length; col++)
            {
                if (_grid[row][col] is '#' or '^')
                    continue;

                _grid[row][col] = '#';

                if (GetAnswerPart1() == -1)
                {
                    answer++;
                }

                Reset();
            }
        }

        return answer;
    }

    private void Reset()
    {
        _grid = input.Select(a => a.ToArray()).ToArray();
        _visitedPositions = [];
        _currentPosition = _startingPosition;
        _currentDirection = Direction.Up;
    }

    private void TurnRight()
    {
        _currentDirection = _currentDirection switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private (int Row, int Column) GetNextPosition()
    {
        Point nextPosition = _currentDirection switch
        {
            Direction.Up => new Up(_currentPosition.Row, _currentPosition.Column),
            Direction.Right => new Right(_currentPosition.Row, _currentPosition.Column),
            Direction.Down => new Down(_currentPosition.Row, _currentPosition.Column),
            Direction.Left => new Left(_currentPosition.Row, _currentPosition.Column),
            _ => throw new ArgumentOutOfRangeException()
        };

        return (nextPosition.Row, nextPosition.Column);
    }
}
