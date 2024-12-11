namespace AdventOfCode2024.Common;

public class Tests
{
    [Fact]
    public void IsLetterInDirection()
    {
        var input = File.ReadLines(@"Common/test_input.txt").Select(x => x.ToCharArray()).ToArray();

        Assert.NotEmpty(input);
        Assert.True(GridHelper.IsCharacterInDirection(input, new LeftUp(1, 1), 'A'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new Up(1, 1), 'B'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new RightUp(1, 1), 'C'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new Right(1, 1), 'F'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new RightDown(1, 1), 'I'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new Down(1, 1), 'H'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new LeftDown(1, 1), 'G'));
        Assert.True(GridHelper.IsCharacterInDirection(input, new Left(1, 1), 'D'));
    }
}