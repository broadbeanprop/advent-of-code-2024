namespace AdventOfCode2024.Day07;

public class Tests
{
    [Theory]
    // Part 1
    [InlineData(@"Day07/example_input.txt", 3749)]
    [InlineData(@"Day07/input.txt", 8401132154762)]

    // Part 2
    [InlineData(@"Day07/example_input.txt", 11387, true)]
    [InlineData(@"Day07/input.txt", 95297119227552, true)]
    public void Part1And2(string fileName, long correctAnswer, bool includeConcat = false)
    {
        var input = File.ReadLines(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswer(includeConcat);
        Assert.Equal(correctAnswer, actualAnswer);
    }
}