namespace AdventOfCode2023.Test;

[Ignore("Incomplete")]
[TestFixture, TestOf(typeof(Problems.Year2023.Day17))]
public class Year2023Day17 : AdventOfCodeTestBase<Problems.Year2023.Day17>
{
  public Year2023Day17() : base(2023, 16)
  {
  }

  [TestCase("24134323113\r\n32154535356\r\n32552456542", 0)]
  [TestCase("11111\r\n99999", 21)]
  [TestCase("2413432311323\r\n3215453535623\r\n3255245654254\r\n3446585845452\r\n4546657867536\r\n1438598798454\r\n4457876987766\r\n3637877979653\r\n4654967986887\r\n4564679986453\r\n1224686865563\r\n2546548887735\r\n4322674655533", 102)]
  [Test, TestOf(nameof(Problems.Year2023.Day17.Part1))]
  public void Year2023Day17_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day17.Part1))]
  public void Year2023Day17_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(8389));
  }

  [TestCase("2413432311323\r\n3215453535623\r\n3255245654254\r\n3446585845452\r\n4546657867536\r\n1438598798454\r\n4457876987766\r\n3637877979653\r\n4654967986887\r\n4564679986453\r\n1224686865563\r\n2546548887735\r\n4322674655533", 102)]
  [Test, TestOf(nameof(Problems.Year2023.Day17.Part2))]
  public void Year2023Day17_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day17.Part2))]
  public void Year2023Day17_Part2_Solution()
  {
    // Act
    var result = long.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(8564));
  }
}

