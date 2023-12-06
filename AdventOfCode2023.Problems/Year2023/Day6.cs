using AdventOfCode2023.Utility;

namespace AdventOfCode2023.Problems.Year2023;

public class Day6 : IProblem
{
  public string Part1(IEnumerable<string> input)
  {
    var times = StringUtility.GetIntegersFromLine(input.First(), @"\s+").ToList();
    var distances = StringUtility.GetIntegersFromLine(input.Where(l => !string.IsNullOrEmpty(l)).Last(), @"\s+").ToList();
    double product = 1;

    for (var i = 0; i < times.Count; i++)
    {
      product *= GetNumberOfWaysToWin(times[i], distances[i]);
    }

    return $"{product}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var time = long.Parse(string.Join("", StringUtility.GetIntegersFromLine(input.First(), @"\s+").Select(x => $"{x}")));
    var distance = long.Parse(string.Join("", StringUtility.GetIntegersFromLine(input.Where(l => !string.IsNullOrEmpty(l)).Last(), @"\s+").Select(x => $"{x}")));

    return $"{GetNumberOfWaysToWin(time, distance)}";
  }

  private static double GetNumberOfWaysToWin(long time, long distance)
  {
    var roots = MathUtility.FindRoots(-1, time, -distance).OrderBy(x => x);
    var lowerRoot = Math.Ceiling(roots.First());
    var upperRoot = Math.Floor(roots.Last());

    if (lowerRoot == roots.First()) lowerRoot++;
    if (upperRoot == roots.Last()) upperRoot--;

    return upperRoot - lowerRoot + 1;
  }
}

// x(7-x) >= 9
// 7x-x^2 >= 9
// -9+7x-x^2 >= 0
// -b +/- sqrt(b^2 - 4ac) / 2a
// a = -1, b = 7, c = -9
// -7 +/- sqrt(7^2 - 4*-1*-9) / 2*-1
// -7 +/- sqrt(49 - 36) / -2
// -7 +/- sqrt(13) / -2
// -7 + sqrt(13) / -2 ~ 1.69 ~ 2, -7 - sqrt(13) / -2 ~ 5.3 ~ 5