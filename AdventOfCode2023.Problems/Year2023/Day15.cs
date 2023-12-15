using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AdventOfCode2023.Problems.Year2023;

public class Day15 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    return $"{input.First().Split(",").Sum(HASH)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var boxes = Enumerable.Range(1, 256).Select(i => new LinkedList<string>()).ToList();
    var focalLengths = new Dictionary<string, int>();

    foreach (var seq in input.First().Split(","))
    {
      Match match = Regex.Match(seq, @"([^-=]+)([-=])(\d*)");

      var label = match.Groups[1].Value;
      var op = match.Groups[2].Value;
      var focalLength = op == "=" ? int.Parse(match.Groups[3].Value) : 0;
      var hash = HASH(label);
      var box = boxes[hash];

      focalLengths[label] = focalLength;

      if (op == "-" && box.Find(label) is var toRemove && toRemove != null)
      {
        box.Remove(toRemove);
      }
      else if (op == "=")
      {
        if (box.Find(label) is var toAdd && toAdd != null)
        {
          toAdd.Value = label;
        }
        else
        {
          box.AddLast(label);
        }
      }
    }

    return $"{boxes.Select((b, i) => b.Select((l, j) => focalLengths[l] * (j + 1) * (i + 1)).Sum()).Sum()}";
  }

  private static int HASH(string input) => input.Aggregate(0, (acc, c) => (acc + c) * 17 % 256);
}