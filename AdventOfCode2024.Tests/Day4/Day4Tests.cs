using AdventOfCode2024.Day4;

namespace AdventOfCode2024.Tests.Day4;

public class Day4Tests
{
    [Theory]
    [InlineData(@"Day4/example_input.txt", 18)]
    [InlineData(@"Day4/input.txt", 2414)]
    public void Part1(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetWords();

        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Theory]
    [InlineData(@"Day4/example_input.txt", 9)]
    [InlineData(@"Day4/input.txt", 1871)]
    public void Part2(string fileName, int correctAnswer)
    {
        var input = File.ReadLines(fileName).Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);

        var actualAnswer = main.GetXMases();

        Assert.Equal(correctAnswer, actualAnswer);
    }

    [Fact]
    public void IsLetterInDirection()
    {
        var input = File.ReadLines(@"Day4/test_input.txt").Select(x => x.ToCharArray()).ToArray();
        Assert.NotEmpty(input);

        var main = new Main(input);

        Assert.True(main.IsLetterInDirection(new Main.LeftUp(1, 1), 'A'));
        Assert.True(main.IsLetterInDirection(new Main.Up(1, 1), 'B'));
        Assert.True(main.IsLetterInDirection(new Main.RightUp(1, 1), 'C'));
        Assert.True(main.IsLetterInDirection(new Main.Right(1, 1), 'F'));
        Assert.True(main.IsLetterInDirection(new Main.RightDown(1, 1), 'I'));
        Assert.True(main.IsLetterInDirection(new Main.Down(1, 1), 'H'));
        Assert.True(main.IsLetterInDirection(new Main.LeftDown(1, 1), 'G'));
        Assert.True(main.IsLetterInDirection(new Main.Left(1, 1), 'D'));
    }
}