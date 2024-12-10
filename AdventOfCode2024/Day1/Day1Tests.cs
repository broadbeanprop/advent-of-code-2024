namespace AdventOfCode2024.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData(@"Day1/example_input.txt", 11)]
    [InlineData(@"Day1/input.txt", 1830467)]
    public void Part1(string fileName, int expectedTotalDistance)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);
        var actualTotalDistance = main.GetTotalDistance();

        Assert.Equal(expectedTotalDistance, actualTotalDistance);
    }

    [Theory]
    [InlineData(@"Day1/example_input.txt", 31)]
    [InlineData(@"Day1/input.txt", 26674158)]
    public void Part2(string fileName, int expectedSimilarityScore)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);
        var actualSimilarityScore = main.GetSimilarityScore();

        Assert.Equal(expectedSimilarityScore, actualSimilarityScore);
    }
}