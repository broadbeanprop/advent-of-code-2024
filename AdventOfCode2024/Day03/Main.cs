using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03;

public partial class Main(string input)
{
    public int GetPart1Answer()
    {
        var answer = 0;

        var instructions = MulInstructions().Matches(input).Select(x => x.Value);

        foreach (var instruction in instructions)
        {
            var numbers = instruction[4..^1].Split(',').Select(int.Parse).ToArray();
            answer += numbers[0] * numbers[1];
        }

        return answer;
    }

    public int GetPart2Answer()
    {
        var answer = 0;
        var executeInstruction = true;
        var instructions = MulDoDontInstructions().Matches(input).Select(x => x.Value);

        foreach (var instruction in instructions)
        {
            if (instruction == "do()")
                executeInstruction = true;

            else if (instruction == "don't()")
                executeInstruction = false;

            else if (executeInstruction)
            {
                var numbers = instruction[4..^1].Split(',').Select(int.Parse).ToArray();
                answer += numbers[0] * numbers[1];
            }
        }

        return answer;
    }

    [GeneratedRegex(@"mul\([0-9]{1,3},[0-9]{1,3}\)")]
    private static partial Regex MulInstructions();

    [GeneratedRegex(@"(mul\([0-9]{1,3},[0-9]{1,3}\))|(do\(\))|(don't\(\))")]
    private static partial Regex MulDoDontInstructions();
}