
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Problems.Year2023;

public class Day9 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var sum = input
      .Where(l => !string.IsNullOrEmpty(l))
      .Select(l => Regex.Matches(l, @"\-?\d+").Cast<Match>().Select(x => int.Parse(x.Value)))
      .Select(n => AddToSequence(n.ToList()))
      .Sum();

    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var sum = input
      .Where(l => !string.IsNullOrEmpty(l))
      .Select(l => Regex.Matches(l, @"\-?\d+").Cast<Match>().Select(x => int.Parse(x.Value)))
      .Select(n => SubtractFromSequence(n.ToList()))
      .Sum();

    return $"{sum}";
  }

  private static int AddToSequence(IList<int> seq)
  {
    if (seq.All(x => x == 0)) return 0;

    var newSeq = new List<int>();

    for (var i = 0; i < seq.Count - 1; i++) 
    {
      newSeq.Add(seq[i + 1] - seq[i]);
    }

    return seq.Last() + AddToSequence(newSeq);
  }

  private static int SubtractFromSequence(IList<int> seq)
  {
    if (seq.All(x => x == 0)) return 0;

    var newSeq = new List<int>();

    for (var i = 0; i < seq.Count - 1; i++)
    {
      newSeq.Add(seq[i + 1] - seq[i]);
    }

    return seq.First() - SubtractFromSequence(newSeq);
  }
}