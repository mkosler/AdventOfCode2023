using System.Diagnostics;

namespace AdventOfCode2023.Utility;

public static class ListExtensions
{
  public static IList<(T, T)> ToSequentialPairs<T>(this IList<T>? list)
  {
    if (list == null) throw new ArgumentNullException(nameof(list));
    
    var pairedList = new List<(T, T)>();

    for (var i = 0; i < list.Count - 1; i += 2)
    {
      pairedList.Add((list[i], list[i + 1]));
    }

    return pairedList;
  }

  public static IDictionary<(int X, int Y), char> ToCharacterMap(this IList<string> input)
  {
    var map = new Dictionary<(int X, int Y), char>();

    for (var y = 0; y < input.Count; y++)
    {
      var length = input[y].Length;

      for (var x = 0; x < length; x++)
      {
        map[(x, y)] = input[y][x];
      }
    }

    return map;
  }

  public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
  {
    var enumerators = source.Select(e => e.GetEnumerator()).ToArray();

    try
    {
      while (enumerators.All(e => e.MoveNext())) yield return enumerators.Select(e => e.Current).ToArray();
    }
    finally
    {
      Array.ForEach(enumerators, e => e.Dispose());
    }
  }

  public static IEnumerable<IEnumerable<T>> RotateClockwise<T>(this IEnumerable<IEnumerable<T>> source)
  {
    return source.Transpose().Select(x => x.Reverse());
  }
  
  public static IEnumerable<IEnumerable<T>> RotateCounterclockwise<T>(this IEnumerable<IEnumerable<T>> source)
  {
    return source.Select(x => x.Reverse()).Transpose();
  }
}