using System.Text.RegularExpressions;

namespace AdventOfCode2023.Problems.Year2023;

public class Day1 : IProblem
{
    public string Part1(IEnumerable<string> input)
    {
      var calibrationValue = input
        .Where(l => !string.IsNullOrEmpty(l))
        .Select(x => x.Where(c => char.IsDigit(c)).ToList())
        .Select(x => $"{x[0]}{x[^1]}")
        .Select(int.Parse)
        .Sum();

        return $"{calibrationValue}";
    }

    public string Part2(IEnumerable<string> input)
    {
      var regex = @"(one|two|three|four|five|six|seven|eight|nine|1|2|3|4|5|6|7|8|9)";
      var wordsAsDigits = new Dictionary<string, string>
      {
        { "one", "1" },
        { "1", "1" },
        { "two", "2" },
        { "2", "2" },
        { "three", "3" },
        { "3", "3" },
        { "four", "4" },
        { "4", "4" },
        { "five", "5" },
        { "5", "5" },
        { "six", "6" },
        { "6", "6" },
        { "seven", "7" },
        { "7", "7" },
        { "eight", "8" },
        { "8", "8" },
        { "nine", "9" },
        { "9", "9" }
      };

      var sum = 0;
    
      foreach (var l in input.Where(x => !string.IsNullOrEmpty(x)))
      {
        var leftMatch = Regex.Match(l, regex).Value;
        var rightMatch = Regex.Match(l, regex, RegexOptions.RightToLeft).Value;

        var calibrationValue = int.Parse($"{wordsAsDigits[leftMatch]}{wordsAsDigits[rightMatch]}");

        sum += calibrationValue;
      }

      return $"{sum}";
    }
}