namespace AdventOfCode2024.Day07;

public class Main(IEnumerable<string> input)
{
    public long GetAnswer(bool includeConcat = false)
    {
        long answer = 0;

        foreach (var equationLine in input)
        {
            var equation = ParseEquation(equationLine);
            var possibleResults = new List<long>();

            foreach (var currentNumber in equation.Numbers)
            {
                if (possibleResults.Count == 0)
                {
                    possibleResults.Add(currentNumber);
                    continue;
                }

                var tempList = new List<long>();

                foreach (var result in possibleResults)
                {
                    tempList.Add(result + currentNumber);
                    tempList.Add(result * currentNumber);

                    if (includeConcat)
                        tempList.Add(long.Parse($"{result}{currentNumber}"));
                }

                possibleResults = tempList;
            }

            if (possibleResults.Contains(equation.TestValue))
            {
                answer += equation.TestValue;
            }
        }

        return answer;
    }

    private (long TestValue, List<int> Numbers) ParseEquation(string equationLine)
    {
        var parts = equationLine.Split(':');
        var testValue = long.Parse(parts.First());
        var numbers = parts.Last().Trim().Split(' ').Select(int.Parse).ToList();

        return (testValue, numbers);
    }
}
