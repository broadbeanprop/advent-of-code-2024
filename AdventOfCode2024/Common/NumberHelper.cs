namespace AdventOfCode2024.Common;

public static class NumberHelper
{
    public static int Difference (int a, int b) =>
        Math.Max(a,b) - Math.Min(a,b);

    public static int GetNextAtEqualDistance(int number1, int number2)
    {
        var diff = Difference(number1, number2);
        return number1 < number2 ? number2 + diff : number2 - diff;
    }
}