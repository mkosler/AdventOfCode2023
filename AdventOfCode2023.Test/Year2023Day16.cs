namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day16))]
public class Year2023Day16 : AdventOfCodeTestBase<Problems.Year2023.Day16>
{
  public Year2023Day16() : base(2023, 16)
  {
  }

  [TestCase(".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n..../.\\\\..\r\n.-.-/..|..\r\n.|....-|.\\\r\n..//.|....", 46)]
  [Test, TestOf(nameof(Problems.Year2023.Day16.Part1))]
  public void Year2023Day16_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day16.Part1))]
  public void Year2023Day16_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(8389));
  }

  [TestCase(".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n..../.\\\\..\r\n.-.-/..|..\r\n.|....-|.\\\r\n..//.|....", 51)]
  [Test, TestOf(nameof(Problems.Year2023.Day16.Part2))]
  public void Year2023Day16_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day16.Part2))]
  public void Year2023Day16_Part2_Solution()
  {
    // Act
    var result = long.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(8564));
  }
}
