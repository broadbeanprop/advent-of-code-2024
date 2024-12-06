using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Tests.Day6;

public class Day6Tests
{
    [Theory]
    [InlineData(@"Day6/example_input.txt", 41)]
    [InlineData(@"Day6/input.txt", 5145)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        main.FindCurrentPosition();
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day6/example_input.txt", 6)]
    [InlineData(@"Day6/input.txt", 1523)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        main.FindCurrentPosition();
        var actualAnswer = main.GetAnswerPart2();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}