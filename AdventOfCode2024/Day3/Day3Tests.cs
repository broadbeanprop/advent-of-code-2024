namespace AdventOfCode2024.Day3;

public class Day3Tests
{
    [Theory]
    [InlineData(@"Day3/example_input.txt", 161)]
    [InlineData(@"Day3/input.txt", 175615763)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetPart1Answer();

        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day3/example_input_2.txt", 48)]
    [InlineData(@"Day3/input.txt", 74361272)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetPart2Answer();

        Assert.Equal(correctAnswer, actualAnswer);
    }
}