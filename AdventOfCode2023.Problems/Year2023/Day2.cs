namespace AdventOfCode2023.Problems.Year2023;

public class Day2 : IProblem
{
  private readonly string[] _colors = new string[] { "red", "green", "blue" };

  public string Part1(IEnumerable<string> input)
  {
    var maximums = new Dictionary<string, int>
    {
      ["red"] = 12,
      ["green"] = 13,
      ["blue"] = 14
    };

    var sum = 0;

    foreach (var l in input.Where(x => !string.IsNullOrEmpty(x)))
    {
      var (id, turns) = GenerateGame(l);

      if (IsGamePossible(turns, maximums)) sum += id;
    }

    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var sum = 0;

    foreach (var l in input.Where(x => !string.IsNullOrEmpty(x)))
    {
      var (id, turns) = GenerateGame(l);

      var maximums = _colors.Select(c => (Color: c, Max: turns.Select(t => t.ContainsKey(c) ? t[c] : 0).Max()));

      var power = maximums.Aggregate(1, (acc, c) => acc * c.Max);

      sum += power;
    }

    return $"{sum}";
  }

  private static int GetInteger(string input) => int.Parse(string.Join("", input.Where(char.IsDigit)));

  private static bool IsGamePossible(List<Dictionary<string, int>> turns, Dictionary<string, int> maximums)
  {
    foreach (var m in maximums)
    {
      if (turns.Any(t => t.ContainsKey(m.Key) && t[m.Key] > m.Value)) return false;
    }

    return true;
  }

  private (int Id, List<Dictionary<string, int>> Turns) GenerateGame(string input)
  {
    var split = input.Split(": ");
    var id = GetInteger(split[0]);
    var rawTurns = split[1];

    var turns = new List<Dictionary<string, int>>();

    foreach (var t in rawTurns.Split("; "))
    {
      var colors = new Dictionary<string, int>();

      foreach (var c in t.Split(", "))
      {
        foreach (var ac in _colors) if (c.Contains(ac)) colors[ac] = GetInteger(c);
      }

      turns.Add(colors);
    }

    return (id, turns);
  }
}