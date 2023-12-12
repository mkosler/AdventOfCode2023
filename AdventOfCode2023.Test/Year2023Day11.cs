namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day11))]
public class Year2023Day11 : AdventOfCodeTestBase<Problems.Year2023.Day11>
{
  public Year2023Day11() : base(2023, 11)
  {
  }

  [TestCase("...#......\r\n.......#..\r\n#.........\r\n..........\r\n......#...\r\n.#........\r\n.........#\r\n..........\r\n.......#..\r\n#...#.....", 374)]
  [Test, TestOf(nameof(Problems.Year2023.Day11.Part1))]
  public void Year2023Day11_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day11.Part1))]
  public void Year2023Day11_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(9563821));
  }

  [Ignore("Examples use smaller values for expansion")]
  [TestCase("...#......\r\n.......#..\r\n#.........\r\n..........\r\n......#...\r\n.#........\r\n.........#\r\n..........\r\n.......#..\r\n#...#.....", 1030)]
  [Test, TestOf(nameof(Problems.Year2023.Day11.Part2))]
  public void Year2023Day11_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day11.Part2))]
  public void Year2023Day11_Part2_Solution()
  {
    // Act
    var result = long.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(827009909817));
  }
}

