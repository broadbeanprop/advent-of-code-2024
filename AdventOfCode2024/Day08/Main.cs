using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day08;

public class Main(char[][] input)
{
    private readonly List<Antinode> _antinodes = [];

    public int GetAnswerPart1()
    {
        var antennas = GridHelper.FindInGrid(input, '.', true)
            .Select(x => new Antenna(input[x.Row][x.Column], x.Row, x.Column));

        var groupedAntennas = antennas.GroupBy(x => x.Frequency);

        foreach (var group in groupedAntennas)
        {
            foreach (var antenna1 in group)
            {
                foreach (var antenna2 in group)
                {
                    if (antenna1.Row == antenna2.Row && antenna1.Column == antenna2.Column)
                        continue;

                    var nextRow = NumberHelper.GetNextAtEqualDistance(antenna1.Row, antenna2.Row);
                    var nextColumn = NumberHelper.GetNextAtEqualDistance(antenna1.Column, antenna2.Column);

                    if (GridHelper.IsWithinBounds(input, nextRow, nextColumn))
                        _antinodes.Add(new Antinode(nextRow, nextColumn));
                }
            }
        }

        return _antinodes.Distinct().Count();
    }

    public int GetAnswerPart2()
    {
        var antennas = GridHelper.FindInGrid(input, '.', true)
            .Select(x => new Antenna(input[x.Row][x.Column], x.Row, x.Column));

        var groupedAntennas = antennas.GroupBy(x => x.Frequency);

        foreach (var group in groupedAntennas)
        {
            foreach (var antenna1 in group)
            {
                foreach (var antenna2 in group)
                {
                    if (antenna1.Row == antenna2.Row && antenna1.Column == antenna2.Column)
                        continue;

                    var antiNode = new Antinode(antenna2.Row, antenna2.Column);
                    _antinodes.Add(antiNode);

                    var nextRow = NumberHelper.GetNextAtEqualDistance(antenna1.Row, antenna2.Row);
                    var nextColumn = NumberHelper.GetNextAtEqualDistance(antenna1.Column, antenna2.Column);
                    var isWithinBounds = GridHelper.IsWithinBounds(input, nextRow, nextColumn);

                    while (isWithinBounds)
                    {
                        var nextAntiNode = new Antinode(nextRow, nextColumn);
                        _antinodes.Add(nextAntiNode);

                        nextRow = NumberHelper.GetNextAtEqualDistance(antiNode.Row, nextAntiNode.Row);
                        nextColumn = NumberHelper.GetNextAtEqualDistance(antiNode.Column, nextAntiNode.Column);
                        isWithinBounds = GridHelper.IsWithinBounds(input, nextRow, nextColumn);
                        antiNode = nextAntiNode;
                    }
                }
            }
        }

        return _antinodes.Distinct().Count();
    }

    private record Antenna(char Frequency, int Row, int Column);
    private record Antinode(int Row, int Column);
}
