using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day10;

public class Main(int[][] input)
{
    public int GetAnswerPart1()
    {
        var trailheads = GridHelper.FindInGrid(input, 0)
            .Select(x => new Coordinate(x.Row, x.Column, input[x.Row][x.Column]))
            .ToList();

        var answer = 0;

        foreach (var trailhead in trailheads)
        {
            FindPaths(trailhead, trailhead);
            answer += trailhead.EndPoints.DistinctBy(x => new { x.Row, x.Column }).Count();
        }

        return answer;
    }

    public int GetAnswerPart2()
    {
        var trailheads = GridHelper.FindInGrid(input, 0)
            .Select(x => new Coordinate(x.Row, x.Column, input[x.Row][x.Column]))
            .ToList();

        var answer = 0;

        foreach (var trailhead in trailheads)
        {
            FindPaths(trailhead, trailhead);
            answer += trailhead.EndPoints.Count;
        }

        return answer;
    }

    private void FindPaths(Coordinate coordinate, Coordinate trailhead)
    {
        var directions = new List<Point>
        {
            new Up(coordinate.Row, coordinate.Column),
            new Right(coordinate.Row, coordinate.Column),
            new Down(coordinate.Row, coordinate.Column),
            new Left(coordinate.Row, coordinate.Column),
        };

        foreach (var direction in directions)
        {
            if (!GridHelper.IsWithinBounds(input, direction.Row, direction.Column))
                continue;

            var nextPoint = new Coordinate(direction.Row, direction.Column, input[direction.Row][direction.Column]);

            if (nextPoint.Height != coordinate.Height + 1)
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

    private record Coordinate (int Row, int Column, int Height) : Point(Row, Column)
    {
        public List<Coordinate> EndPoints { get; } = [];
    }
}
