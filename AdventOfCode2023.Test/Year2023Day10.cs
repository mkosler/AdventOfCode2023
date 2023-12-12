namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day10))]
public class Year2023Day10 : AdventOfCodeTestBase<Problems.Year2023.Day10>
{
  public Year2023Day10() : base(2023, 10)
  {
  }

  [TestCase(".....\r\n.S-7.\r\n.|.|.\r\n.L-J.\r\n.....", 4)]
  [TestCase("..F7.\r\n.FJ|.\r\nSJ.L7\r\n|F--J\r\nLJ...", 8)]
  [Test, TestOf(nameof(Problems.Year2023.Day10.Part1))]
  public void Year2023Day10_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day10.Part1))]
  public void Year2023Day10_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(6812));
  }

  [TestCase("..........\r\n.S------7.\r\n.|F----7|.\r\n.||....||.\r\n.||....||.\r\n.|L-7F-J|.\r\n.|..||..|.\r\n.L--JL--J.\r\n..........", 4)]
  [TestCase(".F----7F7F7F7F-7....\r\n.|F--7||||||||FJ....\r\n.||.FJ||||||||L7....\r\nFJL7L7LJLJ||LJ.L-7..\r\nL--J.L7...LJS7F-7L7.\r\n....F-J..F7FJ|L7L7L7\r\n....L7.F7||L7|.L7L7|\r\n.....|FJLJ|FJ|F7|.LJ\r\n....FJL-7.||.||||...\r\n....L---J.LJ.LJLJ...", 8)]
  [TestCase("FF7FSF7F7F7F7F7F---7\r\nL|LJ||||||||||||F--J\r\nFL-7LJLJ||||||LJL-77\r\nF--JF--7||LJLJ7F7FJ-\r\nL---JF-JLJ.||-FJLJJ7\r\n|F|F-JF---7F7-L7L|7|\r\n|FFJF7L7F-JF7|JL---7\r\n7-L-JL7||F7|L7F-7F7|\r\nL.L7LFJ|||||FJL7||LJ\r\nL7JLJL-JLJLJL--JLJ.L", 10)]
  [Test, TestOf(nameof(Problems.Year2023.Day10.Part2))]
  public void Year2023Day10_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day10.Part2))]
  public void Year2023Day10_Part2_Solution()
  {
    // Act
    var result = long.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(527));
  }
}
