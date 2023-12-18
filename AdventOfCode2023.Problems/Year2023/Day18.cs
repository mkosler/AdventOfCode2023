using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day18 : IProblem
{
  private static readonly IDictionary<string, (int X, int Y)> ALL_DIRECTIONS = new Dictionary<string, (int X, int Y)>
  {
    ["R"] = (1, 0),
    ["D"] = (0, 1),
    ["L"] = (-1, 0),
    ["U"] = (0, -1),
  };

  public string Part1(IEnumerable<string> input)
  {
    var digPlan = new List<(string Direction, int Magnitude)>();

    foreach (var line in input.Where(l => !string.IsNullOrEmpty(l)))
    {
      var match = Regex.Match(line, @"([UDLR])\s+(\d+)\s+\((.+)\)");

      var direction = match.Groups[1].Value;
      var magnitude = int.Parse(match.Groups[2].Value);

      digPlan.Add((direction, magnitude));
    }

    return $"{GetVolume(digPlan)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var digPlan = new List<(string Direction, int Magnitude)>();

    foreach (var line in input.Where(l => !string.IsNullOrEmpty(l)))
    {
      var match = Regex.Match(line, @"([UDLR])\s+(\d+)\s+\((.+)\)");

      var color = match.Groups[3].Value;
      var direction = ALL_DIRECTIONS.Keys.ToList()[int.Parse($"{color[^1]}")];
      var magnitude = Convert.ToInt32(color[1..^1], 16);

      digPlan.Add((direction, magnitude));
    }

    return $"{GetVolume(digPlan)}";
  }

  private static long GetVolume(IEnumerable<(string Direction, int Magnitude)> digPlan)
  {
    (long X, long Y) start = (X: 0, Y: 0);
    var current = start;
    var border = 0;
    var corners = new List<(long X, long Y)>();

    foreach (var (Direction, Magnitude) in digPlan)
    {
      corners.Add(current);
      var (dx, dy) = ALL_DIRECTIONS[Direction];
      border += Magnitude;
      current = (current.X + (dx * Magnitude), current.Y + (dy * Magnitude));
    }

    return Shoelace(corners) + (border / 2) + 1;
  }

  private static long Shoelace(IList<(long X, long Y)> corners)
  {
    long area = 0;

    for (var i = 0; i < corners.Count - 1; i++)
    {
      var (x1, y1) = corners[i];
      var (x2, y2) = corners[i + 1];

      area += x1 * y2 - x2 * y1;
    }

    return Math.Abs(area + corners.Last().X * corners.First().Y - corners.First().X * corners.Last().Y) / 2;
  }
}