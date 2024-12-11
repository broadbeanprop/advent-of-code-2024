namespace AdventOfCode2024.Day09;

public class Main(string input)
{
    public long GetAnswerPart1()
    {
        var blocks = new List<string>();

        var id = 0;
        for (var i = 0; i < input.Length; i += 2)
        {
            var lengthOfFile = int.Parse(input[i].ToString());

            for (var j = 0; j < lengthOfFile; j++)
            {
                blocks.Add(id.ToString());
            }

            if (i + 1 < input.Length)
            {
                var lengthOfFreeSpace = int.Parse(input[i + 1].ToString());
                for (var j = 0; j < lengthOfFreeSpace; j++)
                {
                    blocks.Add(".");
                }
            }

            id++;
        }

        var startIndex = 0;
        var endIndex = blocks.Count - 1;

        while (startIndex < endIndex)
        {
            if (blocks[startIndex] == ".")
            {
                if (blocks[endIndex] != ".")
                {
                    var tmpBlock1 = blocks[startIndex];
                    var tmpBlock2 = blocks[endIndex];

                    blocks[startIndex] = tmpBlock2;
                    blocks[endIndex] = tmpBlock1;

                    startIndex++;
                }

                endIndex--;
            }
            else
            {
                startIndex++;
            }
        }

        return blocks.TakeWhile(t => t != ".").Select((t, i) => i * long.Parse(t)).Sum();
    }

    public long GetAnswerPart2()
    {
        var files = new List<List<string>>();

        var id = 0;
        for (var i = 0; i < input.Length; i += 2)
        {
            var lengthOfFile = int.Parse(input[i].ToString());
            var file = new List<string>();

            for (var j = 0; j < lengthOfFile; j++)
            {
                file.Add(id.ToString());
            }

            files.Add(file);

            if (i + 1 < input.Length)
            {
                var lengthOfFreeSpace = int.Parse(input[i + 1].ToString());

                if (lengthOfFreeSpace > 0)
                {
                    var emptySpace = new List<string>();
                    for (var j = 0; j < lengthOfFreeSpace; j++)
                    {
                        emptySpace.Add(".");
                    }
                    files.Add(emptySpace);
                }
            }

            id++;
        }

        for (var endIndex = files.Count - 1; endIndex >= 0; endIndex--)
        {
            for (var startIndex = 0; startIndex < endIndex; startIndex++)
            {
                if (!files[startIndex].Contains(".") || files[endIndex].Contains("."))
                    continue;

                if (files[startIndex].Count == files[endIndex].Count)
                {
                    var tmpBlock1 = files[startIndex];
                    var tmpBlock2 = files[endIndex];

                    files[startIndex] = tmpBlock2;
                    files[endIndex] = tmpBlock1;
                    break;
                }

                if (files[startIndex].Count <= files[endIndex].Count)
                    continue;

                var tmpStart = new List<string>();
                var tmpEnd = new List<string>();
                var tmpStartEmpty = new List<string>();
                for (var j = 0; j < files[startIndex].Count; j++)
                {
                    if (j < files[endIndex].Count)
                    {
                        tmpStart.Add(files[endIndex][j]);
                        tmpEnd.Add(".");
                    }
                    else
                    {
                        tmpStartEmpty.Add(".");
                    }
                }

                files.Insert(startIndex + 1, tmpStartEmpty);
                endIndex++;
                files[startIndex] = tmpStart;
                files[endIndex] = tmpEnd;
                break;
            }
        }

        var blocks = files.SelectMany(x => x).ToList();

        long result = 0;

        for (var i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] == ".")
                continue;

            result += i * long.Parse(blocks[i]);
        }

        return result;
    }
}
