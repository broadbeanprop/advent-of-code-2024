namespace AdventOfCode2024.Common;

public static class GridHelper
{
    public static List<Point> FindInGrid<TChar>(TChar[][] grid, TChar character, bool characterOpposite = false) where TChar : IEquatable<TChar>
    {
        var options = new List<Point>();

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                var same = grid[row][col].Equals(character);
                if (characterOpposite)
                {
                    if (!same)
                    {
                        options.Add(new Point(row, col));
                    }
                }
                else if (same)
                {
                    options.Add(new Point(row, col));
                }
            }
        }

        return options;
    }

    public static bool IsWithinBounds<TChar>(TChar[][] grid, int row, int column)
    {
        return row > -1 && column > -1 && row < grid[0].Length && column < grid.Length;
    }

    public static bool IsCharacterInDirection<TChar>(TChar[][] grid, Point point, TChar character) where TChar : IEquatable<TChar>
    {
        return IsWithinBounds(grid, point.Row, point.Column) &&
               grid[point.Row][point.Column].Equals(character);
    }
}

public enum Direction { Up, Right, Down, Left }

public record LeftUp(int Row, int Column) : Point(Row - 1, Column - 1);
public record Up(int Row, int Column) : Point(Row - 1, Column);
public record RightUp(int Row, int Column) : Point(Row - 1, Column + 1);
public record Right(int Row, int Column) : Point(Row, Column + 1);
public record RightDown(int Row, int Column) : Point(Row + 1, Column + 1);
public record Down(int Row, int Column) : Point(Row + 1, Column);
public record LeftDown(int Row, int Column) : Point(Row + 1, Column - 1);
public record Left(int Row, int Column) : Point(Row, Column - 1);

public record Point(int Row, int Column);