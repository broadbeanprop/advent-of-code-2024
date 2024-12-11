using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day04;

public class Main(char[][] input)
{
    private readonly char[] _word = "XMAS".ToCharArray();

    public int GetWords()
    {
        const int letterIndex = 0;
        var startingPoints = GridHelper.FindInGrid(input, _word[letterIndex]);

        return startingPoints.Sum(point =>
            FindWordAroundPoint(point, letterIndex + 1));
    }

    public int GetXMases() => FindPotentialAs().Count(IsXMas);

    private int FindWordAroundPoint(Point point, int letterIndex)
    {
        var count = 0;

        if (FindInDirection(new LeftUp(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new Up(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new RightUp(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new Right(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new RightDown(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new Down(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new LeftDown(point.Row, point.Column), letterIndex))
            count++;
        if (FindInDirection(new Left(point.Row, point.Column), letterIndex))
            count++;

        return count;
    }

    private bool FindInDirection(Point point, int letterIndex)
    {
        if (letterIndex + 1 > _word.Length)
            return true;

        if (!GridHelper.IsCharacterInDirection(input, point, _word[letterIndex]))
            return false;

        return point switch
        {
            LeftUp => FindInDirection(new LeftUp(point.Row, point.Column), letterIndex + 1),
            Up => FindInDirection(new Up(point.Row, point.Column), letterIndex + 1),
            RightUp => FindInDirection(new RightUp(point.Row, point.Column), letterIndex + 1),
            Right => FindInDirection(new Right(point.Row, point.Column), letterIndex + 1),
            RightDown => FindInDirection(new RightDown(point.Row, point.Column), letterIndex + 1),
            Down => FindInDirection(new Down(point.Row, point.Column), letterIndex + 1),
            LeftDown => FindInDirection(new LeftDown(point.Row, point.Column), letterIndex + 1),
            Left => FindInDirection(new Left(point.Row, point.Column), letterIndex + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(point))
        };
    }

    private List<(int Row, int Column)> FindPotentialAs()
    {
        var options = new List<(int Row, int Column)>();

        for (var row = 1; row < input.Length - 1; row++)
        {
            for (var col = 1; col < input[row].Length - 1; col++)
            {
                if (input[row][col] == 'A')
                {
                    options.Add((row, col));
                }
            }
        }

        return options;
    }

    private bool IsXMas((int Row, int Column) point)
    {
        var masses = 0;

        if (GridHelper.IsCharacterInDirection(input, new LeftUp(point.Row, point.Column), 'M')
            && GridHelper.IsCharacterInDirection(input, new RightDown(point.Row, point.Column), 'S'))
            masses++;

        if (GridHelper.IsCharacterInDirection(input, new RightUp(point.Row, point.Column), 'M')
            && GridHelper.IsCharacterInDirection(input, new LeftDown(point.Row, point.Column), 'S'))
            masses++;

        if (GridHelper.IsCharacterInDirection(input, new RightDown(point.Row, point.Column), 'M')
            && GridHelper.IsCharacterInDirection(input, new LeftUp(point.Row, point.Column), 'S'))
            masses++;

        if (GridHelper.IsCharacterInDirection(input, new LeftDown(point.Row, point.Column), 'M')
            && GridHelper.IsCharacterInDirection(input, new RightUp(point.Row, point.Column), 'S'))
            masses++;

        return masses == 2;
    }
}