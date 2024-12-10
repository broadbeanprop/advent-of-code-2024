namespace AdventOfCode2024.Day8;

public class Day8Tests
{
    [Theory]
    [InlineData(@"Day8/example_input.txt", 14)]
    [InlineData(@"Day8/input.txt", 301)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day8/example_input.txt", 34)]
    [InlineData(@"Day8/input.txt", 1019)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart2();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}