using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day12;

public class Main(Main.Plot[][] input)
{
    public long GetAnswerPart1()
    {
        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                var currentPlot = input[row][column];
                currentPlot.Row = row;
                currentPlot.Column = column;

                var directions = new List<Point>
                {
                    new Up(row, column),
                    new Right(row, column),
                    new Down(row, column),
                    new Left(row, column),
                };

                foreach (var direction in directions)
                {
                    if (GridHelper.IsWithinBounds(input, direction.Row, direction.Column))
                    {
                        var plotInDirection = input[direction.Row][direction.Column];
                        if (currentPlot.PlantType == plotInDirection.PlantType)
                        {
                            if (currentPlot.RegionId is not null &&
                                plotInDirection.RegionId is not null &&
                                currentPlot.RegionId != plotInDirection.RegionId)
                            {
                                var plotsToUpdate = input.SelectMany(r => r).Where(x => x.RegionId == plotInDirection.RegionId || x.RegionId == currentPlot.RegionId).ToList();
                                foreach (var plot in plotsToUpdate)
                                {
                                    input[plot.Row][plot.Column].RegionId = currentPlot.RegionId;
                                }
                            }

                            var regionId = currentPlot.RegionId ?? plotInDirection.RegionId;
                            currentPlot.RegionId = regionId;
                            plotInDirection.RegionId = regionId;
                        }
                        else
                        {
                            currentPlot.Fences++;
                        }
                    }
                    else
                    {
                        currentPlot.Fences++;
                    }
                }

                currentPlot.RegionId ??= Guid.NewGuid();
            }
        }

        long answer = 0;
        var regions = input.SelectMany(row => row).GroupBy(x => new {x.RegionId, x.PlantType}).ToList();

        foreach (var region in regions)
        {
            var id = region.Key.RegionId ?? throw new ArgumentNullException(nameof(region));

            var fences = region.Sum(x => x.Fences);
            long plots = region.Count();
            answer += (fences * plots);
        }

        return answer;
    }

    public class Plot : IEquatable<Plot>
    {
        public char PlantType { get; init; }
        public Guid? RegionId { get; set; }
        public long Fences { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public bool Equals(Plot? other) => PlantType == other?.PlantType;
    }
}
