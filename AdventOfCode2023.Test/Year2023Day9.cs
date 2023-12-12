namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day9))]
public class Year2023Day9 : AdventOfCodeTestBase<Problems.Year2023.Day9>
{
  public Year2023Day9() : base(2023, 9)
  {
  }

  [TestCase("0 3 6 9 12 15\r\n1 3 6 10 15 21\r\n10 13 16 21 30 45", 114)]
  [Test, TestOf(nameof(Problems.Year2023.Day9.Part1))]
  public void Year2023Day9_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day9.Part1))]
  public void Year2023Day9_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(1980437560));
  }

  [TestCase("0 3 6 9 12 15\r\n1 3 6 10 15 21\r\n10 13 16 21 30 45", 2)]
  [Test, TestOf(nameof(Problems.Year2023.Day9.Part2))]
  public void Year2023Day9_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day9.Part2))]
  public void Year2023Day9_Part2_Solution()
  {
    // Act
    var result = long.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(977));
  }
}