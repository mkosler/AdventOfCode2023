namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day6))]
public class Year2023Day6 : AdventOfCodeTestBase<Problems.Year2023.Day6>
{
  public Year2023Day6() : base(2023, 6)
  {
  }

  [TestCase("Time:      7  15   30\r\nDistance:  9  40  200", 288)]
  [Test, TestOf(nameof(Problems.Year2023.Day6.Part1))]
  public void Year2023Day6_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day6.Part1))]
  public void Year2023Day6_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(633080));
  }

  [TestCase("Time:      7  15   30\r\nDistance:  9  40  200", 71503)]
  [Test, TestOf(nameof(Problems.Year2023.Day6.Part2))]
  public void Year2023Day6_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day6.Part2))]
  public void Year2023Day6_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(20048741));
  }
}


