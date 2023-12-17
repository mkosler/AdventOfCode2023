using System.Reflection;
using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day17 : IProblem
{
  private static readonly IEnumerable<(int X, int Y)> ALL_DIRECTIONS = new List<(int X, int Y)> { (1, 0), (-1, 0), (0, 1), (0, -1) };

  public string Part1(IEnumerable<string> input)
  {
    var map = input.Where(l => !string.IsNullOrEmpty(l)).ToList().ToIntegerMap();
    var tl = (X: 0, Y: 0);
    var br = (X: map.Max(kv => kv.Key.X), Y: map.Max(kv => kv.Key.Y));

    return $"{FindLeastCumulativeHeatLoss(map, tl, br)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    throw new NotImplementedException();
  }

  private static int FindLeastCumulativeHeatLoss(IDictionary<(int X, int Y), int> map, (int X, int Y) source, (int X, int Y) target)
  {
    var cumulativeHeatLoss = map.ToDictionary(kv => kv.Key, kv => int.MaxValue);
    var parent = map.ToDictionary(kv => kv.Key, kv => ((int X, int Y)?)null);
    var unvisited = map.Select(kv => kv.Key).ToList();

    // Set sources cumulative heat loss to 0
    cumulativeHeatLoss[source] = 0;

    while (unvisited.Any())
    {
      var current = unvisited.OrderBy(p => cumulativeHeatLoss[p]).First();

      if (current == target) break;

      unvisited.Remove(current);

      var neighbors = GetNeighbors(current, parent).Intersect(unvisited);

      foreach (var n in neighbors)
      {
        var alternativeCHL = cumulativeHeatLoss[current] + map[n];

        if (alternativeCHL < cumulativeHeatLoss[n])
        {
          cumulativeHeatLoss[n] = alternativeCHL;
          parent[n] = current;
        }
      }
    }

    return cumulativeHeatLoss[target];
  }

  private static IEnumerable<(int X, int Y)> GetNeighbors((int X, int Y) node, IDictionary<(int X, int Y), (int X, int Y)?> parent)
  {
    var current = node;
    var diffs = new List<(int X, int Y)>();

    for (var i = 0; i < 3; i++)
    {
      var p = parent[current];

      if (p == null) break;

      diffs.Add((current.X - (p?.X ?? 0), current.Y - (p?.Y ?? 0)));

      current = p ?? throw new Exception("HUH");
    }

    var directions = ALL_DIRECTIONS.Where(d => diffs.Count != 3 || !diffs.All(x => x == diffs[0]) || d != diffs[0]);

    return directions.Select(d => (node.X + d.X, node.Y + d.Y));
  }
}