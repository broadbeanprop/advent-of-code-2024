namespace AdventOfCode2024.Day02;

public class Tests
{
    [Theory]
    [InlineData(@"Day02/example_input.txt", 2)]
    [InlineData(@"Day02/input.txt", 534)]
    [InlineData(@"Day02/example_input.txt", 4, true)]
    [InlineData(@"Day02/input.txt", 577, true)]
    public void Part1And2(string fileName, int expectedSafeReports, bool applyProblemDampener = false)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);

        var actualSafeReports = main.GetSafeReportAmount(applyProblemDampener);

        Assert.Equal(expectedSafeReports, actualSafeReports);
    }
}