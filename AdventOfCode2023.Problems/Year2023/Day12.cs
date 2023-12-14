
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Problems.Year2023;

public class Day12 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    throw new NotImplementedException();
  }

  public string Part2(IEnumerable<string> input)
  {
    throw new NotImplementedException();
  }

  private static void GetPermutations(string arrangement, IEnumerable<int> numbers)
  {
    var expandedArrangement = $".{arrangement}.";
    var remainingNumbers = new List<int>();

    foreach (var n in numbers)
    {
      var str = new string('#', n);
      var wrappedStr = $".{str}.";

      if (expandedArrangement.Contains(wrappedStr))
      {
        var regex = new Regex(Regex.Escape(str));
        expandedArrangement = regex.Replace(expandedArrangement, "", 1);
      }
      else
      {
        remainingNumbers.Add(n);
      }
    }

    // Find all numbers that already are evident, reading from left to right
    // var buffer = "";

    // for (var i = 0; i < arrangement.Length; i++)
    // {
    //   var ch = arrangement[i];

    //   if (ch == '#')
    //   {
    //     buffer += ch;
    //   }
    // }

    // var buffer = "";

    // for (var i = 0; i < arrangement.Length; i++)
    // {
    //   var ch = arrangement[i];

    //   if (ch != '.')
    //   {
    //     buffer += ch;
    //   }
    //   else if (buffer.Length > 0)
    //   {

    //   }
    // }
  }
}