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

  public static long GCD(long a, long b)
  {
    if (a == 0) return b;

    return GCD(b % a, a);
  }

  public static long LCM(IList<int> elements, int index = 0)
  {
    if (index == elements.Count - 1) return elements[index];

    var a = elements[index];
    var b = LCM(elements, index + 1);

    return a * b / GCD(a, b);
  }
}