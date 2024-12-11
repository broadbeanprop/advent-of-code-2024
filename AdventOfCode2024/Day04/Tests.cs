namespace AdventOfCode2024.Day04;

public class Tests
{
    [Theory]
    [InlineData(@"Day04/example_input.txt", 18)]
    [InlineData(@"Day04/input.txt", 2414)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetWords();

        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day04/example_input.txt", 9)]
    [InlineData(@"Day04/input.txt", 1871)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetXMases();

        Assert.Equal(correctAnswer, actualAnswer);
    }
}