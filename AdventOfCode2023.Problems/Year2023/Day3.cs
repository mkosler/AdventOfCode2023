using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2023.Problems.Year2023;

public class Day3 : IProblem
{
  public class Cell
  {
    public int X;
    public int Y;
    public char Ch;
    public bool IsNumber;
    public int? FullNumber;
    public Cell? Head;

    public Cell(int x, int y, char ch, bool isNumber) => (X, Y, Ch, IsNumber) = (x, y, ch, isNumber);
  }

  public string Part1(IEnumerable<string> input)
  {
    var grid = GenerateGrid(input);
    var includedNumberCells = new List<Cell>();

    foreach (var symbol in grid.Where(c => !c.IsNumber))
    {
      var neighborNumbers = FindAdjacentNumbers(grid, symbol);

      foreach (var nn in neighborNumbers)
      {
        if (!includedNumberCells.Any(c => c.X == nn.X && c.Y == nn.Y)) includedNumberCells.Add(nn);
      }
    }

    return $"{includedNumberCells.Sum(c => c.FullNumber)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var grid = GenerateGrid(input);
    var sum = 0;

    foreach (var potentialGear in grid.Where(c => c.Ch == '*'))
    {
      var neighborNumbers = FindAdjacentNumbers(grid, potentialGear);

      if (neighborNumbers.Count() == 2)
      {
        sum += neighborNumbers.Aggregate(1, (acc, c) => acc * c.FullNumber ?? throw new Exception("What?"));
      }
    }

    return $"{sum}";
  }

  private static IEnumerable<Cell> GenerateGrid(IEnumerable<string> input)
  {
    var grid = new List<Cell>();
    var y = 0;
    var numberBuffer = "";
    var numberBufferCells = new List<Cell>();

    foreach (var l in input.Where(x => !string.IsNullOrEmpty(x)))
    {
      for (var x = 0; x < l.Length; x++)
      {
        var ch = l[x];
        var isNumber = char.IsDigit(ch);
        var cell = new Cell(x, y, ch, isNumber);

        if (isNumber)
        {
          numberBuffer += ch;

          numberBufferCells.Add(cell);
        }
        else if (numberBufferCells.Any())
        {
          var number = int.Parse(numberBuffer);

          for (var i = 0; i < numberBufferCells.Count; i++)
          {
            var c = numberBufferCells[i];

            c.FullNumber = number;
            c.Head = numberBufferCells[0];
          }

          numberBuffer = "";
          numberBufferCells = new List<Cell>();
        }

        if (ch != '.') grid.Add(cell);
      }

      if (numberBufferCells.Any())
      {
        var number = int.Parse(numberBuffer);

        for (var i = 0; i < numberBufferCells.Count; i++)
        {
          var c = numberBufferCells[i];

          c.FullNumber = number;
          c.Head = numberBufferCells[0];
        }

        numberBuffer = "";
        numberBufferCells = new List<Cell>();
      }

      y++;
    }

    return grid;
  }

  private static IEnumerable<Cell> FindAdjacentNumbers(IEnumerable<Cell> grid, Cell symbol)
  {
    var set = new List<Cell>();
    var offsets = new int[] { -1, 0, 1 };

    foreach (var ox in offsets)
    {
      foreach (var oy in offsets)
      {
        var numberNeighbor = grid.SingleOrDefault(c => c.IsNumber && c.X == symbol.X + ox && c.Y == symbol.Y + oy);

        if (numberNeighbor != null && !set.Any(c => c.FullNumber == (numberNeighbor.Head?.FullNumber ?? 0)))
        {
          set.Add(numberNeighbor.Head ?? throw new Exception("Que?"));
        }
      }
    }

    return set;
  }
}

// 123.
// .*..
// 456.
// ...+