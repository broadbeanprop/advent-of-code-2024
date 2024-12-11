namespace AdventOfCode2024.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData(@"Day11/example_input.txt", 55312)]
    [InlineData(@"Day11/input.txt", 217812)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadAllText(fileName).Split(' ').ToList();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day11/example_input.txt", 55312, 25)]
    [InlineData(@"Day11/input.txt", 217812, 25)]
    [InlineData(@"Day11/input.txt", 259112729857522, 75)]
    public void Part2(string fileName, long correctAnswer, int blinkCount)
    {
        var input = File.ReadAllText(fileName).Split(' ').ToList();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart2(blinkCount);
        Assert.Equal(correctAnswer, actualAnswer);
    }
}