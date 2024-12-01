using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day1;

public partial class Main
{
    private readonly List<int> _leftList = [];
    private readonly List<int> _rightList = [];

    private int[] _orderedLeftList = null!;
    private int[] _orderedRightList = null!;

    public Main(string[] input)
    {
        ParseInput(input);
    }

    public int GetTotalDistance()
    {
        var totalDistance = 0;

        var length = _orderedLeftList.Length;
        for (var i = 0; i < length; i++)
        {
            totalDistance += Difference(_orderedLeftList[i], _orderedRightList[i]);
        }

        return totalDistance;
    }

    public int GetSimilarityScore()
    {
        var similarityScore = 0;

        foreach (var number in _leftList)
        {
            var appearances = _rightList.Count(i => i == number);
            similarityScore += number * appearances;
        }

        return similarityScore;
    }

    private void ParseInput(string[] input)
    {
        foreach (var line in input)
        {
            var splitLine = ThreeSpaces().Split(line);
            _leftList.Add(int.Parse(splitLine[0]));
            _rightList.Add(int.Parse(splitLine[1]));
        }

        _orderedLeftList = _leftList.Order().ToArray();
        _orderedRightList = _rightList.Order().ToArray();
    }

    private static int Difference (int a, int b) {
        return Math.Max(a,b) - Math.Min(a,b);
    }

    [GeneratedRegex(@"\s{3}")]
    private static partial Regex ThreeSpaces();
}