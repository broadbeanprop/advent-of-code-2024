namespace AdventOfCode2024.Day5;

public class Main
{
    private readonly List<string[]> _incorrectUpdates = [];

    private IEnumerable<string[]> _rules = null!;
    private IEnumerable<string[]> _updates = null!;

    public Main(string input)
    {
        ParseInput(input);
    }

    private void ParseInput(string input)
    {
        var parts = input.Split("\n\n");
        _rules = parts[0].Split('\n').Select(x => x.Split('|'));
        _updates = parts[1].Split('\n').Select(x => x.Split(','));
    }

    public int GetAnswerPart1()
    {
        var answer = 0;

        foreach (var update in _updates)
        {
            var isUpdateCorrect = true;

            foreach (var rule in _rules)
            {
                var first = Array.IndexOf(update, rule[0]);
                var second = Array.IndexOf(update, rule[1]);

                if (first is -1 || second is -1)
                    continue;

                if (first < second)
                    continue;

                isUpdateCorrect = false;
                _incorrectUpdates.Add(update);
                break;
            }

            if (!isUpdateCorrect)
                continue;

            answer += int.Parse(update[update.Length / 2]);
        }

        return answer;
    }

    public int GetAnswerPart2()
    {
        var fixedUpdates = new List<string[]>();

        foreach (var update in _incorrectUpdates)
        {
            var fixedUpdate = new List<string>();

            foreach (var page in update)
            {
                if (fixedUpdate.Count == 0)
                {
                    fixedUpdate.Add(page);
                    continue;
                }

                var indicesOfPagesBefore = new List<int>();
                var indicesOfPagesAfter = new List<int>();

                foreach (var rule in _rules)
                {
                    if (page == rule[0])
                    {
                        var indexOfPageAfter = fixedUpdate.IndexOf(rule[1]);
                        if (indexOfPageAfter > -1)
                            indicesOfPagesAfter.Add(indexOfPageAfter);
                    }

                    if (page == rule[1])
                    {
                        var indexOfPageBefore = fixedUpdate.IndexOf(rule[0]);
                        if (indexOfPageBefore > -1)
                            indicesOfPagesBefore.Add(indexOfPageBefore);
                    }
                }

                int? minIndex = null;
                int? maxIndex = null;

                if (indicesOfPagesBefore.Count > 0)
                {
                    minIndex = indicesOfPagesBefore.Max() + 1;
                }

                if (indicesOfPagesAfter.Count > 0)
                {
                    maxIndex = indicesOfPagesAfter.Min();
                }

                var index = minIndex ?? maxIndex ?? throw new Exception();
                fixedUpdate.Insert(index, page);
            }

            fixedUpdates.Add(fixedUpdate.ToArray());
        }

        return fixedUpdates.Sum(update => int.Parse(update[update.Length / 2]));
    }
}