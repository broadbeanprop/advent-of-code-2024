using AdventOfCode2024.Day7;

namespace AdventOfCode2024.Tests.Day7;

public class Day7Tests
{
    [Theory]
    // Part 1
    [InlineData(@"Day7/example_input.txt", 3749)]
    [InlineData(@"Day7/input.txt", 8401132154762)]

    // Part 2
    [InlineData(@"Day7/example_input.txt", 11387, true)]
    [InlineData(@"Day7/input.txt", 95297119227552, true)]
    public void Part1And2(string fileName, long correctAnswer, bool includeConcat = false)
    {
        var input = File.ReadLines(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswer(includeConcat);
        Assert.Equal(correctAnswer, actualAnswer);
    }
}