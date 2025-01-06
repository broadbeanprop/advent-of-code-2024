namespace AdventOfCode2024.Day12;

public class Tests
{
    [Theory]
    // [InlineData(@"Day12/example_input1.txt", 140)]
    // [InlineData(@"Day12/example_input2.txt", 772)]
    // [InlineData(@"Day12/example_input3.txt", 1930)]
    [InlineData(@"Day12/input.txt", 1319878)] // Diff: 422
    // [InlineData(@"Day12/test_input.txt", 0)] // 12412?
    public void Part1(string fileName, long correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.Select(y => new Main.Plot { PlantType = y }).ToArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);
        var actualAnswer = main.GetAnswerPart1();
        Assert.Equal(correctAnswer, actualAnswer);
    }
}