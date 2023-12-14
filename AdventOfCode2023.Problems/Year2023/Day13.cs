
namespace AdventOfCode2023.Problems.Year2023;

public class Day13 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var patterns = GeneratePatterns(input);
    var sum = 0;

    foreach (var (Rows, Columns) in patterns)
    {
      if (TryFindMirror(Columns, out var result))
      {
        sum += result;
      }
      else if (TryFindMirror(Rows, out result))
      {
        sum += result * 100;
      }
    }

    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var patterns = GeneratePatterns(input);
    var sum = 0;

    foreach (var (Rows, Columns) in patterns)
    {
      if (TryFindSmudgedMirror(Columns, out var result))
      {
        sum += result;
      }
      else if (TryFindSmudgedMirror(Rows, out result))
      {
        sum += result * 100;
      }
    }

    return $"{sum}";
  }

  private static bool TryFindMirror(List<string> input, out int result)
  {
    result = default;

    for (var i = 0; i < input.Count - 1; i++)
    {
      if (CheckIfMirror(input, i, i + 1))
      {
        result = i + 1;
        return true;
      }
    }

    return false;
  }

  private static bool CheckIfMirror(List<string> input, int leftIndex, int rightIndex)
  {
    if (input[leftIndex] == input[rightIndex])
    {
      if (leftIndex == 0 || rightIndex == input.Count - 1) return true;

      return CheckIfMirror(input, leftIndex - 1, rightIndex + 1);
    }

    return false;
  }

  private static bool TryFindSmudgedMirror(List<string> input, out int result)
  {
    result = default;

    for (var i = 0; i < input.Count - 1; i++)
    {
      if (CheckIfSmudgedMirror(input, i, i + 1))
      {
        result = i + 1;
        return true;
      }
    }

    return false;
  }

  private static bool CheckIfSmudgedMirror(List<string> input, int leftIndex, int rightIndex, bool usedFix = false)
  {
    var leftStr = input[leftIndex];
    var rightStr = input[rightIndex];

    if (leftStr == rightStr)
    {
      if (leftIndex == 0 || rightIndex == input.Count - 1) return usedFix; // The problem states we must have made a repair

      return CheckIfSmudgedMirror(input, leftIndex - 1, rightIndex + 1, usedFix);
    }

    // If we haven't already used up our fix, see if any substring pairs work for these indexes
    if (!usedFix)
    {
      var length = leftStr.Length;

      for (var i = 0; i < length; i++)
      {
        var leftSubStr = leftStr.Remove(i, 1);
        var rightSubStr = rightStr.Remove(i, 1);

        if (leftSubStr == rightSubStr)
        {
          if (leftIndex == 0 || rightIndex == input.Count - 1) return true;

          return CheckIfSmudgedMirror(input, leftIndex - 1, rightIndex + 1, true);
        }
      }
    }

    return false;
  }

  private static List<(List<string> Rows, List<string> Columns)> GeneratePatterns(IEnumerable<string> input)
  {
    var patterns = new List<(List<string> Rows, List<string> Columns)>();
    var rows = new List<string>();
    var columns = new List<string>();

    foreach (var line in input)
    {
      if (string.IsNullOrEmpty(line))
      {
        patterns.Add((Rows: rows, Columns: columns));
        rows = new List<string>();
        columns = new List<string>();
      }
      else
      {
        rows.Add(line);

        for (var i = 0; i < line.Length; i++)
        {
          if (columns.Count == i) columns.Add("");
          columns[i] += line[i];
        }
      }
    }

    patterns.Add((Rows: rows, Columns: columns));

    return patterns;
  }
}