namespace AdventOfCode2024.Day06;

public class Tests
{
    [Theory]
    [InlineData(@"Day06/example_input.txt", 41)]
    [InlineData(@"Day06/input.txt", 5145)]
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
    [InlineData(@"Day06/example_input.txt", 6)]

    // TODO: This solution takes ages with the full input, so there must be a better way.
    // [InlineData(@"Day6/input.txt", 1523)]
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