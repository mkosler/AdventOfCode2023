namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day1))]
public class Year2023Day1 : AdventOfCodeTestBase<Problems.Year2023.Day1>
{
  public Year2023Day1() : base(2023, 1)
  {
  }

  [TestCase("1abc2", 12)]
  [TestCase("pqr3stu8vwx", 38)]
  [TestCase("a1b2c3d4e5f", 15)]
  [TestCase("treb7uchet", 77)]
  [TestCase("1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet", 142)]
  [Test, TestOf(nameof(Problems.Year2023.Day1.Part1))]
  public void Year2023Day1_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day1.Part1))]
  public void Year2023Day1_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(55123));
  }

  [TestCase("two1nine", 29)]
  [TestCase("eighttwothree", 83)]
  [TestCase("abcone2threexyz", 13)]
  [TestCase("xtwone3four", 24)]
  [TestCase("4nineeightseven2", 42)]
  [TestCase("zoneight234", 14)]
  [TestCase("7pqrstsixteen", 76)]
  [TestCase("961", 91)]
  [TestCase("twone9twone", 21)]
  [TestCase("two1nine\r\neighttwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen\r\n", 281)]
  [Test, TestOf(nameof(Problems.Year2023.Day1.Part2))]
  public void Year2023Day1_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day1.Part2))]
  public void Year2023Day1_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(55260));
  }
}