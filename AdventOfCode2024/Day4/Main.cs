namespace AdventOfCode2024.Day4;

public class Main(char[][] input)
{
    private readonly char[] _word = "XMAS".ToCharArray();

    public int GetWords()
    {
        const int letterIndex = 0;
        var startingPoints = FindInGrid(_word[letterIndex]);

        return startingPoints.Sum(point =>
            FindWordAroundPoint(point, letterIndex + 1));
    }

    public int GetXMases() => FindPotentialAs().Count(IsXMas);

    public bool IsLetterInDirection(SearchPoint searchPoint, char letter)
    {
        try
        {
            return input[searchPoint.Row][searchPoint.Column] == letter;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }

    private int FindWordAroundPoint((int Row, int Column) point, int letterIndex)
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

    private bool FindInDirection(SearchPoint searchPoint, int letterIndex)
    {
        if (letterIndex + 1 > _word.Length)
            return true;

        if (!IsLetterInDirection(searchPoint, _word[letterIndex]))
            return false;

        return searchPoint switch
        {
            LeftUp => FindInDirection(new LeftUp(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            Up => FindInDirection(new Up(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            RightUp => FindInDirection(new RightUp(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            Right => FindInDirection(new Right(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            RightDown => FindInDirection(new RightDown(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            Down => FindInDirection(new Down(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            LeftDown => FindInDirection(new LeftDown(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            Left => FindInDirection(new Left(searchPoint.Row, searchPoint.Column), letterIndex + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(searchPoint))
        };
    }

    private List<(int Row, int Column)> FindInGrid(char letter)
    {
        var options = new List<(int Row, int Column)>();

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == letter)
                {
                    options.Add((row, col));
                }
            }
        }

        return options;
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

        if (IsLetterInDirection(new LeftUp(point.Row, point.Column), 'M')
            && IsLetterInDirection(new RightDown(point.Row, point.Column), 'S'))
            masses++;

        if (IsLetterInDirection(new RightUp(point.Row, point.Column), 'M')
            && IsLetterInDirection(new LeftDown(point.Row, point.Column), 'S'))
            masses++;

        if (IsLetterInDirection(new RightDown(point.Row, point.Column), 'M')
            && IsLetterInDirection(new LeftUp(point.Row, point.Column), 'S'))
            masses++;

        if (IsLetterInDirection(new LeftDown(point.Row, point.Column), 'M')
            && IsLetterInDirection(new RightUp(point.Row, point.Column), 'S'))
            masses++;

        return masses == 2;
    }

    public record LeftUp(int Row, int Column) : SearchPoint(Row - 1, Column - 1);
    public record Up(int Row, int Column) : SearchPoint(Row - 1, Column);
    public record RightUp(int Row, int Column) : SearchPoint(Row - 1, Column + 1);
    public record Right(int Row, int Column) : SearchPoint(Row, Column + 1);
    public record RightDown(int Row, int Column) : SearchPoint(Row + 1, Column + 1);
    public record Down(int Row, int Column) : SearchPoint(Row + 1, Column);
    public record LeftDown(int Row, int Column) : SearchPoint(Row + 1, Column - 1);
    public record Left(int Row, int Column) : SearchPoint(Row, Column - 1);
    public abstract record SearchPoint(int Row, int Column);
}