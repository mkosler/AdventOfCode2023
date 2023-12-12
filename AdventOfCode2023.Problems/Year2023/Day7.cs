namespace AdventOfCode2023.Problems.Year2023;

public class Day7 : IProblem
{
  public class Hand
  {
    public enum HandType
    {
      HighCard = 0,
      OnePair = 1,
      TwoPair = 2,
      ThreeOfAKind = 4,
      FullHouse = 5,
      FourOfAKind = 6,
      FiveOfAKind = 7
    }

    public HandType Type { get; private set; }
    public string Cards { get; private set; }
    public long Value { get; set; }
    public int Bid { get; private set; }

    public Hand(string cards, int bid, bool isPart2 = false)
    {
      Cards = cards;
      Bid = bid;
      Type = GetHandType(isPart2);
    }

    private HandType GetHandType(bool isPart2 = false)
    {
      var groupings = Cards.GroupBy(ch => ch);

      if (!isPart2)
      {
        var maxCount = groupings.Max(g => g.Count());

        if (maxCount == 5) return HandType.FiveOfAKind;

        if (maxCount == 4) return HandType.FourOfAKind;

        if (maxCount == 3 && groupings.Any(g => g.Count() == 2)) return HandType.FullHouse;

        if (maxCount == 3) return HandType.ThreeOfAKind;

        if (maxCount == 2 && groupings.Count(g => g.Count() == 2) == 2) return HandType.TwoPair;

        if (maxCount == 2) return HandType.OnePair;

        return HandType.HighCard;
      }
      else
      {
        var nonJGroupings = groupings.Where(g => g.Key != 'J');
        var nonJMaxGrouping = nonJGroupings.Any() ? nonJGroupings.OrderByDescending(g => g.Count()).First() : null;
        var nonJMaxCount = nonJMaxGrouping?.Count() ?? 0;
        var jCount = groupings.FirstOrDefault(g => g.Key == 'J')?.Count() ?? 0;
        var maxCount = nonJMaxCount + jCount;

        if (maxCount == 5) return HandType.FiveOfAKind;

        if (maxCount == 4) return HandType.FourOfAKind;

        if (maxCount == 3 && nonJGroupings.Any(g => g.Key != (nonJMaxGrouping?.Key ?? 'G') && g.Count() == 2)) return HandType.FullHouse;

        if (maxCount == 3) return HandType.ThreeOfAKind;

        if (maxCount == 2 && nonJGroupings.Count(g => g.Count() == 2) == 2) return HandType.TwoPair;

        if (maxCount == 2) return HandType.OnePair;

        return HandType.HighCard;
      }
    }

    public void SetHandValue(IDictionary<char, char> power)
    {
      var buffer = "";

      foreach (var ch in Cards)
      {
        buffer += power[ch];
      }

      Value = Convert.ToInt64(buffer, 16);
    }
  }

  public string Part1(IEnumerable<string> input)
  {
    var power = new Dictionary<char, char>
    {
      { '2', '0' },
      { '3', '1' },
      { '4', '2' },
      { '5', '3' },
      { '6', '4' },
      { '7', '5' },
      { '8', '6' },
      { '9', '7' },
      { 'T', '8' },
      { 'J', '9' },
      { 'Q', 'A' },
      { 'K', 'B' },
      { 'A', 'C' },
    };

    var hands = input
      .Where(l => !string.IsNullOrWhiteSpace(l))
      .Select(l => l.Split(" "))
      .Select(a =>
      {
        var h = new Hand(a[0], int.Parse(a[1]));
        h.SetHandValue(power);
        return h;
      });

    var orderedHands = hands
      .OrderBy(h => h.Type)
      .ThenBy(h => h.Value)
      .ToList();

    long sum = 0;

    for (var i = 0; i < orderedHands.Count; i++)
    {
      var h = orderedHands[i];

      sum += (i + 1) * h.Bid;
    }

    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var power = new Dictionary<char, char>
    {
      { 'J', '0' },
      { '2', '1' },
      { '3', '2' },
      { '4', '3' },
      { '5', '4' },
      { '6', '5' },
      { '7', '6' },
      { '8', '7' },
      { '9', '8' },
      { 'T', '9' },
      { 'Q', 'A' },
      { 'K', 'B' },
      { 'A', 'C' },
    };

    var hands = input
      .Where(l => !string.IsNullOrWhiteSpace(l))
      .Select(l => l.Split(" "))
      .Select(a =>
      {
        var h = new Hand(a[0], int.Parse(a[1]), true);
        h.SetHandValue(power);
        return h;
      });

    var orderedHands = hands
      .OrderBy(h => h.Type)
      .ThenBy(h => h.Value)
      .ToList();

    long sum = 0;

    for (var i = 0; i < orderedHands.Count; i++)
    {
      var h = orderedHands[i];

      sum += (i + 1) * h.Bid;
    }

    return $"{sum}";
  }
}