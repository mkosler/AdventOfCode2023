namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day7))]
public class Year2023Day7 : AdventOfCodeTestBase<Problems.Year2023.Day7>
{
  public Year2023Day7() : base(2023, 7)
  {
  }

  [TestCase("32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483", 6440)]
  [Test, TestOf(nameof(Problems.Year2023.Day7.Part1))]
  public void Year2023Day7_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day7.Part1))]
  public void Year2023Day7_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(248559379));
  }

  [TestCase("32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483", 5905)]
  [Test, TestOf(nameof(Problems.Year2023.Day7.Part2))]
  public void Year2023Day7_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day7.Part2))]
  public void Year2023Day7_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(249631254));
  }
}
