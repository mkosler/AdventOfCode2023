using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day14 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var rolled = RollLeft(input.Where(l => !string.IsNullOrEmpty(l)).RotateClockwise())
      .RotateCounterclockwise();

    return $"{CalculateScore(rolled.ToList())}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var rolled = input.Where(l => !string.IsNullOrEmpty(l));
    var copyRolled = new List<string>(rolled).AsEnumerable();
    var patterns = new List<string>();
    var loopStart = 0;

    for (var j = 0; j < 1000000000; j++)
    {
      for (var i = 0; i < 4; i++)
      {
        rolled = RollLeft(rolled.RotateClockwise());
      }

      var pattern = string.Join(Environment.NewLine, rolled);

      if (!patterns.Contains(pattern))
      {
        patterns.Add(pattern);
      }
      else
      {
        loopStart = patterns.IndexOf(pattern);
        break;
      }
    }

    var mod = ((1000000000 - loopStart - 1) % (patterns.Count - loopStart)) + loopStart;

    var modPattern = patterns[mod];

    var otherScore = CalculateScore(modPattern.Split(Environment.NewLine));

    return $"{otherScore}";
  }

  private static int CalculateScore(IList<IEnumerable<char>> input)
  {
    var sum = 0;

    for (var i = 0; i < input.Count; i++)
    {
      sum += input[i].Count(ch => ch == 'O') * (input.Count - i);
    }

    return sum;
  }

  private static IEnumerable<string> RollLeft(IEnumerable<IEnumerable<char>> source)
  {
    var rolled = new List<string>();

    foreach (var line in source)
    {
      var full = "";
      var buffer = "";

      foreach (var ch in line)
      {
        if (ch != '#')
        {
          buffer += ch;
        }
        else
        {
          full += $"{string.Concat(buffer.OrderBy(x => x))}#";
          buffer = "";
        }
      }

      if (buffer.Any())
      {
        full += $"{string.Concat(buffer.OrderBy(x => x))}";
      }

      rolled.Add(full);
    }

    return rolled;
  }
}