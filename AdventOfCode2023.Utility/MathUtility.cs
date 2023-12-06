namespace AdventOfCode2023.Utility;

public static class MathUtility
{
  public static IEnumerable<double> FindRoots(double a, double b, double c)
  {
    var front = -b;
    var b2 = b * b;
    var fourac = 4 * a * c;
    var sqrt = Math.Sqrt(b2 - fourac);
    var twoa = 2 * a;

    return new List<double>
    {
      (front + sqrt) / twoa,
      (front - sqrt) / twoa,
    };
  }
}