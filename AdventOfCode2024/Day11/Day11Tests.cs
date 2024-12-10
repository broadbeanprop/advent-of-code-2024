namespace AdventOfCode2024.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData(@"Day11/example_input.txt", 0)]
    // [InlineData(@"Day11/input.txt", 0)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}