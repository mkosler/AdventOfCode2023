namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day3))]
public class Year2023Day3 : AdventOfCodeTestBase<Problems.Year2023.Day3>
{
  public Year2023Day3() : base(2023, 3)
  {
  }

  [TestCase("467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..", 4361)]
  [TestCase("123.\r\n.*..\r\n456.\r\n...+", 579)]
  [Test, TestOf(nameof(Problems.Year2023.Day3.Part1))]
  public void Year2023Day3_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day3.Part1))]
  public void Year2023Day3_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(544664));
  }

  [TestCase("467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..", 467835)]
  [Test, TestOf(nameof(Problems.Year2023.Day3.Part2))]
  public void Year2023Day3_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day3.Part2))]
  public void Year2023Day3_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(84495585));
  }
}
