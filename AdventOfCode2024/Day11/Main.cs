namespace AdventOfCode2024.Day11;

public class Main(List<string> stones)
{
    private const int Blinks = 25;

    public int GetAnswerPart1()
    {
        for (var blinks = 1; blinks <= Blinks; blinks++)
        {
            for (var i = 0; i < stones.Count; i++)
            {
                if (stones[i] == "0")
                {
                    stones[i] = "1";
                }
                else if (stones[i].Length % 2 == 0)
                {
                    var tmpStone1 = stones[i].Substring(0, stones[i].Length / 2);
                    var tmpStone2 = stones[i].Substring(stones[i].Length / 2).TrimStart('0').PadLeft(1, '0');

                    stones[i] = tmpStone1;
                    stones.Insert(i + 1, tmpStone2);
                    i++;
                }
                else
                {
                    stones[i] = (long.Parse(stones[i]) * 2024).ToString();
                }
            }
        }

        return stones.Count;
    }

    // This solution fails the requirement to preserve the order of the stones, but does give the correct answer to the puzzle
    // The solution to part 1 does preserve the order of the stones, but with 75 blinks it takes too long to calculate
    public long GetAnswerPart2(int blinkCount)
    {
        var dict = new Dictionary<string, long>();

        foreach (var stone in stones)
        {
            if (!dict.TryAdd(stone, 1))
                dict[stone] += 1;
        }

        for (var blinks = 1; blinks <= blinkCount; blinks++)
        {
            var currentStones = dict.Where(kvp => kvp.Value > 0).ToList();
            foreach (var stone in currentStones)
            {
                dict[stone.Key] -= stone.Value;

                if (stone.Key == "0")
                {
                    if (!dict.TryAdd("1", stone.Value))
                        dict["1"] += stone.Value;
                }
                else if (stone.Key.Length % 2 == 0)
                {
                    var tmpStone1 = stone.Key.Substring(0, stone.Key.Length / 2);
                    var tmpStone2 = stone.Key.Substring(stone.Key.Length / 2).TrimStart('0').PadLeft(1, '0');

                    if (!dict.TryAdd(tmpStone1, stone.Value))
                        dict[tmpStone1] += stone.Value;

                    if (!dict.TryAdd(tmpStone2, stone.Value))
                        dict[tmpStone2] += stone.Value;
                }
                else
                {
                    var tmpStone = (long.Parse(stone.Key) * 2024).ToString();

                    if (!dict.TryAdd(tmpStone, stone.Value))
                        dict[tmpStone] += stone.Value;
                }
            }
        }

        return dict.Values.Sum();
    }
}
