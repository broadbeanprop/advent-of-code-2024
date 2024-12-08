namespace AdventOfCode2024.Day8;

public class Main(char[][] input)
{
    private readonly List<Antenna> _antennas = [];
    private readonly List<Antinode> _antinodes = [];

    public int GetAnswerPart1()
    {
        FindAntennas();

        var groupedAntennas = _antennas.GroupBy(x => x.Frequency);

        foreach (var group in groupedAntennas)
        {
            foreach (var antenna1 in group)
            {
                foreach (var antenna2 in group)
                {
                    if (antenna1.Row == antenna2.Row && antenna1.Column == antenna2.Column)
                        continue;

                    var nextRow = GetNext(antenna1.Row, antenna2.Row);
                    var nextColumn = GetNext(antenna1.Column, antenna2.Column);

                    if (IsWithinBounds(nextRow, nextColumn))
                        _antinodes.Add(new Antinode(nextRow, nextColumn));
                }
            }
        }

        return _antinodes.Distinct().Count();
    }

    public int GetAnswerPart2()
    {
        FindAntennas();

        var groupedAntennas = _antennas.GroupBy(x => x.Frequency);

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

                    var nextRow = GetNext(antenna1.Row, antenna2.Row);
                    var nextColumn = GetNext(antenna1.Column, antenna2.Column);
                    var isWithinBounds = IsWithinBounds(nextRow, nextColumn);

                    while (isWithinBounds)
                    {
                        var nextAntiNode = new Antinode(nextRow, nextColumn);
                        _antinodes.Add(nextAntiNode);

                        nextRow = GetNext(antiNode.Row, nextAntiNode.Row);
                        nextColumn = GetNext(antiNode.Column, nextAntiNode.Column);
                        isWithinBounds = IsWithinBounds(nextRow, nextColumn);
                        antiNode = nextAntiNode;
                    }
                }
            }
        }

        return _antinodes.Distinct().Count();
    }

    private bool IsWithinBounds(int row, int column)
    {
        return row > -1 && column > -1 && row < input[0].Length && column < input.Length;
    }

    private int GetNext(int index1, int index2)
    {
        var diff = Difference(index1, index2);
        return index1 < index2 ? index2 + diff : index2 - diff;
    }

    private void FindAntennas()
    {
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] is not '.')
                {
                    _antennas.Add(new Antenna(input[row][col], row, col));
                }
            }
        }
    }

    private static int Difference (int a, int b) {
        return Math.Max(a,b) - Math.Min(a,b);
    }

    private record Antenna(char Frequency, int Row, int Column);
    private record Antinode(int Row, int Column);
}
