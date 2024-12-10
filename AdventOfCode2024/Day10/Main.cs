namespace AdventOfCode2024.Day10;

public class Main(int[][] input)
{
    private readonly List<Point> _trailheads = [];

    public int GetAnswerPart1()
    {
        FindTrailHeads();

        var answer = 0;

        foreach (var trailhead in _trailheads)
        {
            FindPaths(trailhead, trailhead);
            answer += trailhead.EndPoints.DistinctBy(x => new { x.Row, x.Column }).Count();
        }

        return answer;
    }

    public int GetAnswerPart2()
    {
        FindTrailHeads();

        var answer = 0;

        foreach (var trailhead in _trailheads)
        {
            FindPaths(trailhead, trailhead);
            answer += trailhead.EndPoints.Count;
        }

        return answer;
    }

    private void FindPaths(Point point, Point trailhead)
    {
        var directions = new List<Coordinate>
        {
            new Up(point.Row, point.Column),
            new Right(point.Row, point.Column),
            new Down(point.Row, point.Column),
            new Left(point.Row, point.Column),
        };

        foreach (var direction in directions)
        {
            if (!IsWithinBounds(direction.Row, direction.Column))
                continue;

            var nextPoint = new Point(direction.Row, direction.Column, input[direction.Row][direction.Column]);

            if (nextPoint.Height != point.Height + 1)
                continue;

            if (nextPoint.Height == 9)
            {
                trailhead.EndPoints.Add(nextPoint);
            }
            else
            {
                FindPaths(nextPoint, trailhead);
            }
        }
    }

    private void FindTrailHeads()
    {
        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input.Length; column++)
            {
                if (input[row][column] != 0)
                    continue;

                _trailheads.Add(new Point(row, column, input[row][column]));
            }
        }
    }

    private bool IsWithinBounds(int row, int column)
    {
        return row > -1 && column > -1 && row < input[0].Length && column < input.Length;
    }

    private record Point (int Row, int Column, int Height) : Coordinate(Row, Column)
    {
        public List<Point> EndPoints { get; } = [];
    }

    private record Up(int Row, int Column) : Coordinate(Row - 1, Column);
    private record Right(int Row, int Column) : Coordinate(Row, Column + 1);
    private record Down(int Row, int Column) : Coordinate(Row + 1, Column);
    private record Left(int Row, int Column) : Coordinate(Row, Column - 1);
    private abstract record Coordinate(int Row, int Column);
}
