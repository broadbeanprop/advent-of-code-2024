using AdventOfCode2024.Day2;

namespace AdventOfCode2024.Tests.Day2;

public class Day2Tests
{
    [Theory]
    [InlineData(@"Day2/example_input.txt", 2)]
    [InlineData(@"Day2/input.txt", 534)]
    [InlineData(@"Day2/example_input.txt", 4, true)]
    [InlineData(@"Day2/input.txt", 577, true)]
    public void Part1And2(string fileName, int expectedSafeReports, bool applyProblemDampener = false)
    {
        var lines = File.ReadLines(fileName).ToArray();
        Assert.NotEmpty(lines);

        var main = new Main(lines);

        var actualSafeReports = main.GetSafeReportAmount(applyProblemDampener);

        Assert.Equal(expectedSafeReports, actualSafeReports);
    }
}