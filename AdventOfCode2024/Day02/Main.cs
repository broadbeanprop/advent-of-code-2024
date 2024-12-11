using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02;

public partial class Main
{
    private readonly List<Report> _reports = [];

    public Main(string[] input)
    {
        ParseInput(input);
    }

    public int GetSafeReportAmount(bool applyProblemDampener)
    {
        var safeReportAmount = 0;

        foreach (var report in _reports)
        {
            if (IsReportSafe(report.Levels))
            {
                safeReportAmount++;
                continue;
            }

            if (!applyProblemDampener)
                continue;

            for (var i = 0; i < report.Levels.Count; i++)
            {
                var levels = new List<int>(report.Levels);
                levels.RemoveAt(i);

                if (!IsReportSafe(levels))
                    continue;

                safeReportAmount++;
                break;
            }
        }

        return safeReportAmount;
    }

    private static bool IsReportSafe(List<int> levels)
    {
        var sorted = levels.OrderBy(x => x);
        var sortedDescending = levels.OrderByDescending(x => x);

        if (!levels.SequenceEqual(sorted) && !levels.SequenceEqual(sortedDescending))
            return false;

        for (var i = 1; i < levels.Count; i++)
        {
            var difference = NumberHelper.Difference(levels[i], levels[i - 1]);

            if (difference is < 1 or > 3)
            {
                return false;
            }
        }

        return true;
    }

    private void ParseInput(string[] input)
    {
        foreach (var line in input)
        {
            var levels = OneSpace()
                .Split(line)
                .Select(int.Parse)
                .ToList();

            _reports.Add(new Report{ Levels = levels });
        }
    }

    [GeneratedRegex(@"\s{1}")]
    private static partial Regex OneSpace();

    private class Report
    {
        public List<int> Levels { get; set; } = [];
    }
}