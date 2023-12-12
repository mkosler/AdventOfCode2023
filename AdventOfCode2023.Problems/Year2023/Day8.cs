using System.Text.RegularExpressions;
using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day8 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var inputArray = input.Where(l => !string.IsNullOrEmpty(l)).ToArray();
    var instructions = inputArray[0];
    var map = GenerateMap(inputArray[1..]);
    var current = "AAA";
    var steps = 0;

    while (current != "ZZZ")
    {
      var i = steps % instructions.Length;
      var ch = instructions[i];
      var (Left, Right) = map[current];

      if (ch == 'L') current = Left;
      else if (ch == 'R') current = Right;
      else throw new Exception("Huh?");

      steps++;
    }

    return $"{steps}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var inputArray = input.Where(l => !string.IsNullOrEmpty(l)).ToArray();
    var instructions = inputArray[0];
    var map = GenerateMap(inputArray[1..]);
    var locations = map.Keys.Where(x => x.EndsWith("A"));
    var stepsToFirstZ = new List<int>();

    foreach (var loc in locations)
    {
      var current = loc;
      var steps = 0;

      while (!current.EndsWith("Z"))
      {
        var i = steps % instructions.Length;
        var ch = instructions[i];
        var (Left, Right) = map[current];

        if (ch == 'L') current = Left;
        else if (ch == 'R') current = Right;
        else throw new Exception("Huh?");

        steps++;
      }

      stepsToFirstZ.Add(steps);
    }

    return $"{MathUtility.LCM(stepsToFirstZ)}";
  }

  private static IDictionary<string, (string Left, string Right)> GenerateMap(IEnumerable<string> input)
  {
    var map = new Dictionary<string, (string Left, string Right)>();
  
    foreach (var l in input)
    {
      var matches = Regex.Matches(l, @"(\w+)\s*=\s*\((\w+),\s*(\w+)\)");

      map[matches[0].Groups[1].Value] = (Left: matches[0].Groups[2].Value, Right: matches[0].Groups[3].Value);
    }
  
    return map;
  }
}
