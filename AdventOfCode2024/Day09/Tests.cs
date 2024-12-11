namespace AdventOfCode2024.Day09;

public class Tests
{
    [Theory]
    [InlineData(@"Day09/example_input.txt", 1928)]
    [InlineData(@"Day09/input.txt", 6360094256423)]
    public void Part1(string fileName, long correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day09/example_input.txt", 2858)]
    [InlineData(@"Day09/input.txt", 6379677752410)]
    public void Part2(string fileName, long correctAnswer)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart2();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}