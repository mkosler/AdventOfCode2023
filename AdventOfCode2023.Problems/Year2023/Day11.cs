
namespace AdventOfCode2023.Problems.Year2023;

public class Day11 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var filteredInput = input.Where(l => !string.IsNullOrEmpty(l)).ToList();
    var width = filteredInput.First().Length;
    var height = filteredInput.Count;
    var galaxies = FindGalaxies(filteredInput);
    var emptyXs = Enumerable.Range(0, width).Except(galaxies.Select(p => p.X));
    var emptyYs = Enumerable.Range(0, height).Except(galaxies.Select(p => p.Y));
    var expandedInput = new List<string>();

    for (var y = 0; y < height; y++) 
    {
      var buffer = "";
      var line = filteredInput[y];

      for (var x = 0; x < width; x++)
      {
        buffer += line[x];

        if (emptyXs.Contains(x)) buffer += ".";
      }

      expandedInput.Add(buffer);

      if (emptyYs.Contains(y)) expandedInput.Add(new string('.', buffer.Length));
    }

    var expandedGalaxies = FindGalaxies(expandedInput).ToList();

    var shortestPaths = new Dictionary<(int A, int B), int>();

    for (var i = 0; i < expandedGalaxies.Count; i++)
    {
      for (var j = i + 1; j < expandedGalaxies.Count; j++)
      {
        var pair = (i, j);
        var galaxyA = expandedGalaxies[i];
        var galaxyB = expandedGalaxies[j];
        var dist = Math.Abs(galaxyB.X - galaxyA.X) + Math.Abs(galaxyB.Y - galaxyA.Y);

        if (!shortestPaths.ContainsKey(pair) || (shortestPaths.ContainsKey(pair) && shortestPaths[pair] > dist)) shortestPaths[(i, j)] = dist;
      }
    }

    return $"{shortestPaths.Sum(kv => kv.Value)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var filteredInput = input.Where(l => !string.IsNullOrEmpty(l)).ToList();
    var width = filteredInput.First().Length;
    var height = filteredInput.Count;
    var galaxies = FindGalaxies(filteredInput).ToList();
    var emptyXs = Enumerable.Range(0, width).Except(galaxies.Select(p => p.X));
    var emptyYs = Enumerable.Range(0, height).Except(galaxies.Select(p => p.Y));
    var expansion = 1000000;

    var shortestPaths = new Dictionary<(int A, int B), long>();

    for (var i = 0; i < galaxies.Count; i++)
    {
      for (var j = i + 1; j < galaxies.Count; j++)
      {
        var pair = (i, j);
        var galaxyA = galaxies[i];
        var galaxyB = galaxies[j];

        var distX = Math.Abs(galaxyB.X - galaxyA.X);
        var distY = Math.Abs(galaxyB.Y - galaxyA.Y);

        var rangeX = Enumerable.Range(galaxyA.X <= galaxyB.X ? galaxyA.X : galaxyB.X, distX);
        var rangeY = Enumerable.Range(galaxyA.Y <= galaxyB.Y ? galaxyA.Y : galaxyB.Y, distY);

        var countX = rangeX.Intersect(emptyXs).Count();
        var countY = rangeY.Intersect(emptyYs).Count();

        long oldDist = distX + distY;
        long dist = distX + ((expansion - 1) * countX) + distY + ((expansion - 1) * countY);

        if (!shortestPaths.ContainsKey(pair) || (shortestPaths.ContainsKey(pair) && shortestPaths[pair] > dist)) shortestPaths[(i, j)] = dist;
      }
    }

    return $"{shortestPaths.Sum(kv => kv.Value)}";
  }

  private static IEnumerable<(int X, int Y)> FindGalaxies(IEnumerable<string> input)
  {
    var galaxies = new List<(int X, int Y)>();
    var y = 0;

    foreach (var l in input)
    {
      var x = 0;

      foreach (var ch in l)
      {
        if (ch == '#') galaxies.Add((x, y));

        x++;
      }

      y++;
    }

    return galaxies;
  }
}