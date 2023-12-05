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
}