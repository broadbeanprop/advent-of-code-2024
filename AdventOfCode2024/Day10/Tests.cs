namespace AdventOfCode2024.Day10;

public class Tests
{
    [Theory]
    [InlineData(@"Day10/example_input.txt", 36)]
    [InlineData(@"Day10/input.txt", 796)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day10/example_input.txt", 81)]
    [InlineData(@"Day10/input.txt", 1942)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart2();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}