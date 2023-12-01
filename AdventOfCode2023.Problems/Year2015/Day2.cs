using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2023.Problems.Year2015;

public class Day2 : IProblem
{
    public string Part1(IEnumerable<string> input)
    {
      var squares = input
        .Where(l => !string.IsNullOrEmpty(l))
        .Select(l => l.Split("x").Select(int.Parse).ToList())
        .Select(a => (Length: a[0], Width: a[1], Height: a[2]));
        
      var sum = squares
        .Select(dim => GetSurfaceArea(dim.Length, dim.Width, dim.Height))
        .Sum();

      var smallest = squares
        .Select(dim => new int[] { dim.Length * dim.Height, dim.Length * dim.Width, dim.Height * dim.Width })
        .Select(sides => sides.Min())
        .Sum();

      return $"{sum + smallest}";
    }

    public string Part2(IEnumerable<string> input)
    {
        throw new NotImplementedException();
    }

    public int GetSurfaceArea(int length, int width, int height)
      => (2 * length * width) + (2 * width * height) + (2 * length * height);
}