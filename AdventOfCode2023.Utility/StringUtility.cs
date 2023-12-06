using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AdventOfCode2023.Utility;

public static class StringUtility
{
  public static IEnumerable<int> GetIntegersFromLine(string line, string sep)
  {
    var numbers = new List<int>();

    foreach (var s in Regex.Split(line, sep))
    {
      if (int.TryParse(s, out var result))
      {
        numbers.Add(result);
      }
    }

    return numbers;
  }
}