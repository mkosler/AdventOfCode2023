using System.Diagnostics.CodeAnalysis;
using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day16 : IProblem
{
  private static readonly (int DX, int DY) UP = (0, 1);
  private static readonly (int DX, int DY) DOWN = (0, -1);
  private static readonly (int DX, int DY) LEFT = (-1, 0);
  private static readonly (int DX, int DY) RIGHT = (1, 0);

  public string Part1(IEnumerable<string> input)
  {
    var map = input.Where(l => !string.IsNullOrEmpty(l)).ToList().ToCharacterMap();

    return $"{GetEnergizedCount(map, (0, 0, 1, 0))}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var map = input.Where(l => !string.IsNullOrEmpty(l)).ToList().ToCharacterMap();
    var width = map.Max(kv => kv.Key.X) + 1;
    var height = map.Max(kv => kv.Key.Y) + 1;
    var maxEnergizedCount = int.MinValue;

    // Horizontal
    for (var y = 0; y < height; y++)
    {
      maxEnergizedCount = new int[] { maxEnergizedCount, GetEnergizedCount(map, (0, y, RIGHT.DX, RIGHT.DY)), GetEnergizedCount(map, (width - 1, y, LEFT.DX, LEFT.DY))}.Max();
    }

    // Vertical
    for (var x = 0; x < width; x++)
    {
      maxEnergizedCount = new int[] { maxEnergizedCount, GetEnergizedCount(map, (x, 0, UP.DX, UP.DY)), GetEnergizedCount(map, (x, height - 1, DOWN.DX, DOWN.DY))}.Max();
    }

    return $"{maxEnergizedCount}";
  }

  private static int GetEnergizedCount(IDictionary<(int X, int Y), char> map, (int X, int Y, int DX, int DY) initialHead)
  {
    var heads = new Queue<(int X, int Y, int DX, int DY)>();
    var energizedTilesWithDirection = new HashSet<(int X, int Y, int DX, int DY)>();
    var energizedTiles = new HashSet<(int X, int Y)>();

    // Add the initial head to the queue
    heads.Enqueue(initialHead);

    while (heads.TryDequeue(out var head))
    {
      var headPos = (head.X, head.Y);

      if (map.ContainsKey(headPos) && !energizedTilesWithDirection.Contains(head))
      {
        var tile = map[headPos];

        energizedTiles.Add(headPos);
        energizedTilesWithDirection.Add(head);

        foreach (var (DX, DY) in GetUpdatedVelocity((head.DX, head.DY), tile))
        {
          heads.Enqueue((headPos.X + DX, headPos.Y + DY, DX, DY));
        }
      }
    }

    return energizedTiles.Count;
  }

  private static IEnumerable<(int DX, int DY)> GetUpdatedVelocity((int DX, int DY) delta, char tile)
  {
    if (tile == '-' && !(delta == LEFT || delta == RIGHT))
    {
      return new List<(int DX, int DY)> { LEFT, RIGHT };
    }
    else if (tile == '|' && !(delta == UP || delta == DOWN))
    {
      return new List<(int DX, int DY)> { UP, DOWN };
    }
    else if (tile == '\\')
    {
      return new List<(int DX, int DY)> { (delta.DY, delta.DX) };
    }
    else if (tile == '/')
    {
      return new List<(int DX, int DY)> { (-delta.DY, -delta.DX) };
    }
    else
    {
      return new List<(int DX, int DY)> { delta };
    }
  }
}