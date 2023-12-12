namespace AdventOfCode2023.Problems.Year2023;

public class Day10 : IProblem
{
  private static readonly (int X, int Y) UP = (0, 1);
  private static readonly (int X, int Y) DOWN = (0, -1);
  private static readonly (int X, int Y) LEFT = (-1, 0);
  private static readonly (int X, int Y) RIGHT = (1, 0);

  public string Part1(IEnumerable<string> input)
  {
    var steps = 1;
    var map = GenerateMap(input);
    var start = map.First(kv => kv.Value.Ch == 'S').Key;
    var prev = start;
    // Pick a random direction from start's neighbors
    var (X, Y) = new List<(int X, int Y)> { UP, DOWN, LEFT, RIGHT }.First(p => IsNeighbor(map[(start.X + p.X, start.Y + p.Y)].Ch, p.X, p.Y));
    var current = (X: start.X + X, Y: start.Y + Y);

    while (current != start)
    {
      var (dx, dy) = (current.X - prev.X, current.Y - prev.Y);
      var currentOptions = map[current].Directions;
      var (ndx, ndy) = currentOptions.First(p => p != (-dx, -dy));
      prev = current;
      current = (current.X + ndx, current.Y + ndy);
      steps++;
    }

    return $"{Math.Floor(steps / 2.0)}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var map = GenerateMap(input);
    var start = map.First(kv => kv.Value.Ch == 'S');
    var startPos = start.Key;
    var prev = startPos;
    // Pick a random direction from start's neighbors
    var neighbors = new List<(int X, int Y)> { UP, DOWN, LEFT, RIGHT }
      .Where(p => IsNeighbor(map.ContainsKey((startPos.X + p.X, startPos.Y + p.Y)) ? map[(startPos.X + p.X, startPos.Y + p.Y)].Ch : '.', p.X, p.Y));
    var (X, Y) = neighbors.First();
    var current = (X: startPos.X + X, Y: startPos.Y + Y);
    var loop = new HashSet<(int X, int Y)> { current };

    while (current != startPos)
    {
      var (dx, dy) = (current.X - prev.X, current.Y - prev.Y);
      var currentOptions = map[current].Directions;
      var (ndx, ndy) = currentOptions.First(p => p != (-dx, -dy));
      prev = current;
      current = (current.X + ndx, current.Y + ndy);
      loop.Add(current);
    }

    // Replace S with its appropriate loop character
    if (neighbors.Contains(UP) && neighbors.Contains(DOWN)) map[startPos] = (Ch: '|', start.Value.Directions);
    else if (neighbors.Contains(LEFT) && neighbors.Contains(RIGHT)) map[startPos] = (Ch: '-', start.Value.Directions);
    else if (neighbors.Contains(DOWN) && neighbors.Contains(RIGHT)) map[startPos] = (Ch: 'L', start.Value.Directions);
    else if (neighbors.Contains(DOWN) && neighbors.Contains(LEFT)) map[startPos] = (Ch: 'J', start.Value.Directions);
    else if (neighbors.Contains(UP) && neighbors.Contains(LEFT)) map[startPos] = (Ch: '7', start.Value.Directions);
    else if (neighbors.Contains(UP) && neighbors.Contains(RIGHT)) map[startPos] = (Ch: 'F', start.Value.Directions);

    var interiorPoints = map.Keys.Where(p => IsInterior(map, loop, p.X, p.Y));

    return $"{interiorPoints.Count()}";
  }
    
  private static IDictionary<(int X, int Y), (char Ch, List<(int X, int Y)> Directions)> GenerateMap(IEnumerable<string> input)
  {
    var map = new Dictionary<(int X, int Y), (char Ch, List<(int X, int Y)> Directions)>();
    var y = 0;

    foreach (var line in input.Where(l => !string.IsNullOrEmpty(l)))
    {
      for (var x = 0; x < line.Length; x++) map.Add((x, y), (line[x], GetDirections(line[x])));

      y++;
    }

    return map;
  }

  private static List<(int X, int Y)> GetDirections(char ch) => ch switch
  {
    '|' => new List<(int X, int Y)> { UP, DOWN },
    '-' => new List<(int X, int Y)> { LEFT, RIGHT },
    'L' => new List<(int X, int Y)> { DOWN, RIGHT},
    'J' => new List<(int X, int Y)> { DOWN, LEFT },
    '7' => new List<(int X, int Y)> { UP, LEFT },
    'F' => new List<(int X, int Y)> { UP, RIGHT },
    _ => new List<(int X, int Y)>()
  };

  private static bool IsNeighbor(char nch, int dx, int dy)
  {
    if ((dx, dy) == UP && "|LJ".Contains(nch)) return true;
    if ((dx, dy) == DOWN && "|7F".Contains(nch)) return true;
    if ((dx, dy) == LEFT && "-LF".Contains(nch)) return true;
    if ((dx, dy) == RIGHT && "-J7".Contains(nch)) return true;

    return false;
  }

  private static bool ShouldRevert(char heldCh, char currentCh) => (heldCh == 'F' && currentCh == '7') || (heldCh == 'L' && currentCh == 'J');

  private static bool IsInterior(IDictionary<(int X, int Y), (char Ch, List<(int X, int Y)> Directions)> map, ISet<(int X, int Y)> loop, int x, int y)
  {
    var currentPos = (X: x, Y: y);
    var currentCh = map[currentPos].Ch;
    var count = 0;
    var heldCh = '.';
    var (dx, dy) = (1, 0);

    // If we started on the loop, we are not interior.
    if (loop.Contains(currentPos)) return false;

    while (true)
    {
      if (loop.Contains(currentPos) && "|FL".Contains(currentCh))
      {
        heldCh = currentCh;
        count++;
      }
      else if (loop.Contains(currentPos) && ShouldRevert(heldCh, currentCh))
      {
        heldCh = '.';
        count--;
      }

      var nextPos = (X: currentPos.X + dx, Y: currentPos.Y + dy);

      if (!map.ContainsKey(nextPos)) break;
      currentPos = nextPos;
      currentCh = map[nextPos].Ch;
    }

    if (loop.Contains(currentPos) && ShouldRevert(heldCh, currentCh)) count--;

    return count > 0 && count % 2 == 1;
  }
}