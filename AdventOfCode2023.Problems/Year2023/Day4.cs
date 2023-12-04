
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Problems.Year2023;

public class Day4 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var sum = 0;

    foreach (var card in input.Where(l => !string.IsNullOrEmpty(l)))
    {
      var count = GetWinningNumberCount(card);

      sum += count > 0 ? Convert.ToInt32(Math.Pow(2, count - 1)) : 0;
    }

    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var cardCounts = Enumerable.Repeat(1, input.Where(l => !string.IsNullOrEmpty(l)).Count()).ToList();
    var i = 0;

    foreach (var card in input.Where(l => !string.IsNullOrEmpty(l)))
    {
      var count = GetWinningNumberCount(card);

      for (var j = 0; j < count; j++) cardCounts[j + i + 1] += cardCounts[i];

      i++;
    }

    return $"{cardCounts.Sum()}";
  }

  private static int GetWinningNumberCount(string card)
  {
    var matches = Regex.Match(card, @"Card\s+\d+: (.*) \| (.*)");

    var winningNumbers = matches.Groups[1].Value.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse);
    var myNumbers = matches.Groups[2].Value.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse);

    var myWinningNumbers = myNumbers.Intersect(winningNumbers);

    return myWinningNumbers.Count();
  }
}
