namespace AdventOfCode2024.Day01;

public class Tests
{
    [Theory]
    [InlineData(@"Day01/example_input.txt", 11)]
    [InlineData(@"Day01/input.txt", 1830467)]
    public void Part1(string fileName, int expectedTotalDistance)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);
        var actualTotalDistance = main.GetTotalDistance();

        Assert.Equal(expectedTotalDistance, actualTotalDistance);
    }

    [Theory]
    [InlineData(@"Day01/example_input.txt", 31)]
    [InlineData(@"Day01/input.txt", 26674158)]
    public void Part2(string fileName, int expectedSimilarityScore)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);
        var actualSimilarityScore = main.GetSimilarityScore();

        Assert.Equal(expectedSimilarityScore, actualSimilarityScore);
    }
}