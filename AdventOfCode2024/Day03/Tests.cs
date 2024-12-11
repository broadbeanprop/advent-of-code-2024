namespace AdventOfCode2024.Day03;

public class Tests
{
    [Theory]
    [InlineData(@"Day03/example_input.txt", 161)]
    [InlineData(@"Day03/input.txt", 175615763)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetPart1Answer();

        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day03/example_input_2.txt", 48)]
    [InlineData(@"Day03/input.txt", 74361272)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetPart2Answer();

        Assert.Equal(correctAnswer, actualAnswer);
    }
}