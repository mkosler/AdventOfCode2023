namespace AdventOfCode2023.Problems.Year2015;

public class Day1 : IProblem
{
    public string Part1(IEnumerable<string> input)
    {
        // Assume only one line in the input
        var fullInput = string.Join(Environment.NewLine, input);

        return $"{GetEndFloor(fullInput)}";
    }

    public string Part2(IEnumerable<string> input)
    {
        var fullInput = string.Join(Environment.NewLine, input);

        return $"{GetPositionWhenFirstEnteringBasement(fullInput)}";
    }

    private int GetEndFloor(string input)
    {
      return input.Count(c => c == '(') - input.Count(c => c == ')');
    }

    private int GetPositionWhenFirstEnteringBasement(string input)
    {
      var floor = 0;

      foreach (var (ch, i) in input.Select((c, i) => (c, i)))
      {
        if (ch == '(') floor++;
        else if (ch == ')') floor--;

        if (floor == -1) return i + 1;
      }

      throw new Exception("Input never entered the basement");
    }
}