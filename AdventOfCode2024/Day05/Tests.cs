namespace AdventOfCode2024.Day05;

public class Tests
{
    [Theory]
    [InlineData(@"Day05/example_input.txt", 143, 123)]
    [InlineData(@"Day05/input.txt", 5639, 5273)]
    public void Part1(string fileName, int correctAnswerPart1, int correctAnswerPart2)
    {
        var input = File.ReadAllText(fileName);
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswerPart1 = main.GetAnswerPart1();
        Assert.Equal(correctAnswerPart1, actualAnswerPart1);

        var actualAnswerPart2 = main.GetAnswerPart2();
        Assert.Equal(correctAnswerPart2, actualAnswerPart2);
    }
}